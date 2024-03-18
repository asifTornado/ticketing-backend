﻿using Eapproval.Models;
using Eapproval.Services;
using Eapproval.Services.IServices;
using Eapproval.Helpers.IHelpers;



using System.Text.Json;

namespace Eapproval.Helpers
{
    public class Notifier:INotifier
    {

        INotificationService _notificationService;

        IHelperClass _helperClass;

        public Notifier(INotificationService notificationService, IHelperClass helperClass) {
        
            _notificationService = notificationService;
            _helperClass = helperClass;
          
        
        }

        public async Task InsertNotification(string time, string message, User from, User to, int? ticketId, List<string> mentions = null, string type = "message", string section = "ticketing")
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
