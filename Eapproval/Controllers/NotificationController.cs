using Eapproval.Models;
using Eapproval.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Eapproval.Controllers
{

    [ApiController]
    [Route("/")]
    public class NotificationController : Controller
    {
        NotificationService _notificationService;
        public NotificationController(NotificationService notificationService) {

            _notificationService = notificationService;
        }


        [HttpPost]
        [Route("/getNotifications")]
        public async Task<IActionResult> GetNotifications(IFormCollection data)
        {

            var user = JsonSerializer.Deserialize<User>(data["user"]);
            var result = await _notificationService.GetNotificationsByUser(user.MailAddress, user.EmpName);

            return Ok(result);
                
        }




        [HttpPost]
        [Route("/deleteNotification")]
        public async Task<IActionResult> DeleteNotification(IFormCollection data)
        {
           
            var id = data["id"];

            await _notificationService.RemoveNotification(id);


            return Ok(true);
        }
    }
}
