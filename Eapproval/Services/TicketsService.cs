using Eapproval.Models;
using Eapproval.Services;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Org.BouncyCastle.Tls;

namespace Eapproval.services;

public class TicketsService
{

    private readonly IMongoCollection<Tickets> _tickets;
    private readonly TeamsService _teamsService;
    private readonly CounterService _counterService;

    public TicketsService(TeamsService teamsService, CounterService counterService)
    {
        _teamsService = teamsService;
        _counterService = counterService;
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var mongoDatabase = mongoClient.GetDatabase("eapproval");
        _tickets = mongoDatabase.GetCollection<Tickets>("tickets");
     }


    public async Task<List<TicketsProjected>> GetProjectedTicketsForHandlers(User user)
    {
        var projections = Builders<Tickets>.Projection
                          .Include(ticket => ticket.Id)
                          .Include(ticket => ticket.RequestDate)
                          .Include(ticket => ticket.Number)
                          .Include(ticket => ticket.RaisedBy)

                          .Include(ticket => ticket.CurrentHandler)

                          .Include(ticket => ticket.ProblemDetails)
                          .Include(ticket => ticket.Status);
        var results = await _tickets.Find(new BsonDocument()).Project(projections).ToListAsync();
        List<TicketsProjected> mappedResults = new List<TicketsProjected>();
        
        foreach (var result in results)
        {
            var newTicket = new TicketsProjected()
            {
                Id = result["_id"].ToString(),
                ProblemDetails = result["problemDetails"].ToString(),
                RaisedByEmail = result["raisedBy"]["mailAddress"].ToString(),
                RaisedByName = result["raisedBy"]["empName"].ToString(),
                CurrentHandlerEmail = result["currentHandler"]["mailAddress"].ToString(),
                CurrentHandlerName = result["currentHandler"]["empName"].ToString(),
                Number = result["number"].ToInt32(),
                Status = result["status"].ToString()
            };

            mappedResults.Add(newTicket);
        }

        

        return mappedResults;
    }


    public async Task<List<Tickets>> GetTicketsForHandler(User user) =>
    await _tickets.Find(ticket => ticket.HigherApprover.MailAddress == user.MailAddress || ticket.Supervisor.MailAddress == user.MailAddress || ticket.AssignedTo.MailAddress == user.MailAddress || ticket.CurrentHandler.MailAddress == user.MailAddress || ticket.TicketingHead.MailAddress == user.MailAddress || ticket.RaisedBy.MailAddress == user.MailAddress || ticket.PrevHandler.MailAddress == user.MailAddress || (ticket.Mentions != null && ticket.Mentions.Any(x=>x.EmpName == user.EmpName || x.MailAddress == user.MailAddress))).ToListAsync();


    public async Task<List<Tickets>> GetDepartmentTickets(string userMail)
    {
        var teams = await _teamsService.GetTeamsForHead(userMail);
        var results = await _tickets.Find(ticket => teams.Any(
            team => team.HasServices.HasValue && team.HasServices == true ?
            team.Services.Any(service => service.ServiceName == ticket.ServiceType) :
            ticket.Department == team.Name
        )
        ).ToListAsync();
        return results;
    }

    public async Task<List<Tickets>> GetTicketsRaisedByUser(User user)
    {
        var results = await _tickets.Find(ticket => ticket.RaisedBy.EmpName == user.EmpName).ToListAsync();
        return results;
    }

    public async Task<Tickets?> GetAsync(string id) =>
        await _tickets.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Tickets newTicket) {
        var serial = await _counterService.GetOrCreateCounterAsync();
        newTicket.Number = serial;
        await _tickets.InsertOneAsync(newTicket);
        return;
    }


    public async Task<List<Tickets>> GetAllTickets() =>
   await _tickets.Find(_ => true).ToListAsync();



    public async Task UpdateAsync(string id, Tickets updatedTicket) =>
        await _tickets.ReplaceOneAsync(x => x.Id == id, updatedTicket);

    public async Task RemoveAsync(string id) =>
        await _tickets.DeleteOneAsync(x => x.Id == id);

    public async Task<Tickets?> GetOneTicketByGroups(string group) =>   
        await _tickets.Find(x => x.Groups.Contains(group)).FirstOrDefaultAsync();


    public async Task<List<Tickets>> GetTicketsForLeader(User user)
    {
        var results = await _tickets.Find(x => x.TicketingHead.EmpName == user.EmpName || x.TicketingHead.MailAddress == user.MailAddress).ToListAsync();
        return results;

    }

    public async Task<List<Tickets>> GetTicketsForNormal(User user)
    {
        var results = await _tickets.Find(x => x.RaisedBy.EmpName == user.EmpName || x.RaisedBy.MailAddress == user.MailAddress).ToListAsync();
        return results;
    }


    public async Task<List<Tickets>> GetTicketsForSupport(User user)
    {
        var results = await _tickets.Find(x => (x.AssignedTo.EmpName == user.EmpName || x.AssignedTo.MailAddress == user.EmpName) && x.Accepted == true).ToListAsync();
        return results;
    }



}
