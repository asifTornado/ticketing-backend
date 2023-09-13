using Eapproval.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.ComponentModel;

namespace Eapproval.services;

public class TeamsService
{

    private readonly IMongoCollection<Team> _team;
    private readonly UsersService _usersService;

    public TeamsService( UsersService usersService)
    {
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var mongoDatabase = mongoClient.GetDatabase("eapproval");
        _team = mongoDatabase.GetCollection<Team>("teams");
        _usersService = usersService;
    }


    public async Task<List<SubordinatesClass>> GetConcernedUsers(string name)
    {
        var result = await _team.Find(x => x.Name == name).FirstOrDefaultAsync();
        var users = result.Subordinates;
        return users;
    }


    public async Task<List<Team>> GetAllTeams() =>
    await _team.Find(_ => true).ToListAsync();



    public async Task<Team> GetTeamByName(string Name)
    {
        var result = await _team.Find(Team => Team.Services.Any(service => service.ServiceName == Name) || Team.Name == Name).FirstOrDefaultAsync();
        return result;
    }


    public async Task<List<Team>> GetTeamsForHead(string email)
    {
        var result = await _team.Find(Team => Team.Head.MailAddress == email).ToListAsync();
        return result;
    }

    public async Task<List<User>> GetSupportFromHead(User user)
    {
        var result = await _team.Find(Team => Team.Leaders.Any(x => x.MailAddress == user.MailAddress)).FirstOrDefaultAsync();
        List<User> support = new List<User>();

        var supportUsers = await _usersService.GetSupportUsers(result);

        support = supportUsers;

        return support;
    }


    public async Task<List<User>> GetAllSupport()
    {
        var teams = await _team.Find(_ => true).ToListAsync();
        var support = new List<User>();
        foreach (var team in teams)
        {
            foreach(var subordinate in team.Subordinates)
            {
                support.Add(subordinate.User);
            }
        }

        return support;
    }
    



    public async Task<Team?> GetTeamById(string id)
    {
        return await _team.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateTeam(Team newTeam) =>
        await _team.InsertOneAsync(newTeam);

    public async Task UpdateTeam(string id, Team updatedTeam) =>
        await _team.ReplaceOneAsync(x => x.Id == id, updatedTeam);

    public async Task RemoveTeam(string id) =>
        await _team.DeleteOneAsync(x => x.Id == id);

    public async Task<List<ProblemTypesClass>> GetProblemForUser(User user){
        var team = await _team.Find(x=>x.Subordinates.Any(y => y.User.MailAddress == user.MailAddress)).FirstOrDefaultAsync();
        var problems = team.ProblemTypes;

        return problems;

    }

}
