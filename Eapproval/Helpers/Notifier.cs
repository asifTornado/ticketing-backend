using Eapproval.Models;
using Eapproval.Services;

using System.Text.Json;

namespace Eapproval.Helpers
{
    public class Notifier
    {

        NotificationService _notificationService;
        HelperClass _helperClass;

        public Notifier(NotificationService notificationService, HelperClass helperClass) {
        
            _notificationService = notificationService;
            _helperClass = helperClass;
        
        }

        public async void InsertNotification(string time, string message, User from, User to, string ticketId, List<User> mentions = null, string type = "message")
        {

            var newNotification = new Notification
            {
                Time = time,
                Message = message,
                From = from,
                To = to,
                TicketId = ticketId,
                Type = type,
                Mentions = mentions,
            };


            await _notificationService.InsertNotification(newNotification);



        }
    }
}
