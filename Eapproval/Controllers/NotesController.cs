using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using MongoDB.Bson;
using Eapproval.services;
using Eapproval.Models;
using Eapproval.Helpers;

namespace Eapproval.Controllers
{
    [Route("/")]
    [ApiController]
    public class NotesController : ControllerBase
    {

        private NotesService _notesService;
        private HelperClass _helperClass;
        private TicketsService _ticketService;
        private Notifier _notifier;
        
        public NotesController(Notifier notifier, NotesService notesService, HelperClass helperClass, TicketsService ticketService)
        {
            _notesService = notesService;
            _helperClass = helperClass;
            _ticketService = ticketService;
            _notifier = notifier;
        }
        [HttpPost]
        [Route("/insertNote")]
        public async Task<IActionResult> InsertNote(IFormCollection data)
        {

            var newNote = new Notes()
            {
                TicketId = data["id"],
                Data = data["note"],
                TakenBy = data["userName"],
                Date = data["date"]

            };

            await _notesService.InsertNote(newNote);

            return Ok(newNote);
            




        }


        [HttpPost]
        [Route("/uploadCommentFiles")]
        public async Task<IActionResult> UploadCommentFiles(IFormCollection data)
        {

            var files = await _helperClass.GetFiles(data);

            var newNote = new Notes()
            {
                TicketId = data["id"],
                TakenBy = data["userName"],
                Date = data["date"],
                Type = "file",
                Files = files,
                Caption = data["caption"]


            };

            await _notesService.InsertNote(newNote);

            return Ok(newNote);





        }


        [HttpPost]
        [Route("/makeMentions")]
        public async Task<IActionResult> MakeMentions(IFormCollection data)
        {

            var mentions = JsonSerializer.Deserialize<List<User>>(data["mentions"]);
            var ticket = JsonSerializer.Deserialize<Tickets>(data["ticket"]);
            var user = JsonSerializer.Deserialize<User>(data["user"]);

            var time = _helperClass.GetCurrentTime();
            var newNote = new Notes()
            {
                TicketId = ticket.Id,
                TakenBy = user.EmpName,
                Date = data["date"],
                Type = "mention",
                Mentions = mentions,
                Caption = data["message"]


            };

            ticket.Mentions = mentions;
             _notifier.InsertNotification(time, "Notification", user, null, ticket.Id, mentions, "mention");
            await _ticketService.UpdateAsync(ticket.Id, ticket);
            await _notesService.InsertNote(newNote);

            return Ok(newNote);





        }



        [HttpPost]
        [Route("/getNotes")]
        public async Task<IActionResult> GetNotes(IFormCollection data)
        {


           var result = await _notesService.GetNotesById(data["id"]);

            return Ok(result);





        }
    }
              
}
