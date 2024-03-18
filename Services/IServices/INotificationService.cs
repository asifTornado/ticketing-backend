using Eapproval.Models;

namespace Eapproval.Services.IServices;


public interface INotificationService{

    Task InsertNotification(Notification notification);
    Task<List<Notification>> GetNotificationsByUser(string email, string name);
    Task RemoveNotification(string id);
    Task<Notification> GetNotification(string id);
    Task<List<Notification>> GetNotifications();
    

}