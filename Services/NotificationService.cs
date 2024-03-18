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
        .Include(n => n.To)
        .Include(n => n.From)
        .AsNoTracking().ToListAsync();

        return result;

    }
   

    public async Task<Notification> GetNotification(string id)
    {

        var result = await _context.Notifications
        .Include(n => n.Mentions)
        .Include(n => n.To)
        .Include(n => n.From)
        .AsNoTracking().FirstOrDefaultAsync(x => x.Id == int.Parse(id));
        return result;

    }

    public async Task RemoveNotification(string id){

        var notification = new Notification(){Id = int.Parse(id)};
        _context.Entry(notification).State = EntityState.Deleted;
        await _context.SaveChangesAsync();

    }


    public async Task<List<Notification>> GetNotificationsByUser(string email, string name){

        var result = await _context.Notifications
        .Include(n => n.Mentions)
        .Include(n => n.To)
        .Include(n => n.From)
        .AsNoTracking().Where(x => x.To.MailAddress == email || x.To.EmpName == name || x.Mentions.Any(x => x == email)).ToListAsync();

        return result;

      
    }


    public async Task InsertNotification(Notification notification){

           
      notification.FromId = notification.From.Id;
      notification.ToId = notification.To.Id;

        _context.Entry(notification).State = EntityState.Added;

        await _context.SaveChangesAsync();

 
    } 

}
