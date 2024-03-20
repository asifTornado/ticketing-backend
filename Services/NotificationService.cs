using Eapproval.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Org.BouncyCastle.Tls;
using System.IO;
using Eapproval.Factories.IFactories;
using Dapper;
using Eapproval.Services.IServices;
using Microsoft.EntityFrameworkCore;


namespace Eapproval.Services;



public class NotificationService:INotificationService {

    private IConnection _connection;
    private TicketContext _context;


    public NotificationService(TicketContext context, IConnection connection)
    {
        _connection = connection;
        _context = context;
    }
 

    public async Task<List<Notification>> GetNotifications(){

        var result = await _context.Notifications
        .Include(n => n.Mentions)
        .AsNoTracking().ToListAsync();

        return result;

    }
   

    public async Task<Notification> GetNotification(string id)
    {

        var result = await _context.Notifications
        .AsNoTracking().FirstOrDefaultAsync(x => x.Id == int.Parse(id));
        return result;

    }

    public async Task RemoveNotification(string id){

        var notification = new Notification(){Id = int.Parse(id)};
        _context.Entry(notification).State = EntityState.Deleted;
        await _context.SaveChangesAsync();

    }


    public async Task<List<Notification>> GetNotificationsByUser(string email, string name, int? id){

        var result = await _context.Notifications.AsNoTracking()
        .Include(x => x.From)
        .Select(x => new Notification{
            FromId = x.From.Id,
            TicketId = x.TicketId,
            ToId = x.ToId,
            Mentions = x.Mentions,
            Type = x.Type
        })
        .ToListAsync();
        
        var finalResult = result
        .Where(x => x.ToId == id  || x.Mentions!.Contains(name)).ToList();

        return result;
      
    }


    public async Task InsertNotification(Notification notification){

        _context.Entry(notification).State = EntityState.Added;

        await _context.SaveChangesAsync();

 
    } 

}
