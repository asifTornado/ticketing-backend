using Eapproval.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Org.BouncyCastle.Tls;
using System.IO;


namespace Eapproval.Services;



public class NotificationService {

    private readonly IMongoCollection<Notification> _notification;


    public NotificationService()
    {
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var mongoDatabase = mongoClient.GetDatabase("eapproval");
        _notification = mongoDatabase.GetCollection<Notification>("notifications");
    }

    public async Task<List<Notification>> GetNotifications() =>
    await _notification.Find(_ => true).ToListAsync();

    public async Task<Notification> GetNotification(string id)
    {
        var result = await _notification.Find(x => x.TicketId == id).FirstOrDefaultAsync();
        return result;
    }

    public async Task RemoveNotification(string id) =>
    await _notification.DeleteOneAsync(x => x.Id == id);


    public async Task<List<Notification>> GetNotificationsByUser(string email, string name) =>
await _notification.Find(item =>(item.To != null && (item.To.MailAddress == email || item.To.EmpName == name)) || (item.Mentions != null && item.Mentions.Any(x=>x.EmpName == name || x.MailAddress == email))).ToListAsync();

    public async Task InsertNotification(Notification notification) => await _notification.InsertOneAsync(notification);

}
