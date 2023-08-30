using Eapproval.Helpers;
using Microsoft.AspNetCore.Mvc;
using Eapproval.Models;
using Eapproval.services;
using System.Text.Json;
using MongoDB.Bson;
using System.Runtime.CompilerServices;
using MongoDB.Driver.Core.Authentication;
using Org.BouncyCastle.Ocsp;
using System.IO;
using MongoDB.Driver.Core.Operations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using Eapproval.Services;
using MailKit;
using Microsoft.AspNetCore.Authorization;

namespace Eapproval.Controllers
{
    [ApiController]
    [Route("/")]
    public class TicketController : Controller
    {

        HelperClass _helperClass;
        TicketsService _ticketsService;
        TicketMailer _ticketMailer;
        FileHandler _fileHandler;
        Notifier _notifier;
        UsersService _usersService;
        TeamsService _teamsService;
       
     
        

        public TicketController(TeamsService teamsService, UsersService usersService, HelperClass helperClass, TicketsService ticketsService, TicketMailer ticketMailer, FileHandler fileHandler, Notifier notifier)
        {
            _helperClass = helperClass;
            _ticketsService = ticketsService; 
            _ticketMailer = ticketMailer;
            _fileHandler = fileHandler;
            _notifier = notifier;
            _usersService = usersService;
            _teamsService = teamsService;
        }




        [HttpPost]
        [Route("submitTicket")]
        public async Task<IActionResult> SubmitTicket(IFormCollection data)
        {
            var result = await _helperClass.GetContent(data);
            var ticket = result.ticket;
            var comment = result.comment;
            var user = result.user;
            var fileNames = result.fileNames;
            ticket.Actions = new List<ActionObject>();
            ticket.RaisedBy = user;
            ticket.MadeCloseRequest = false;
            string message;


            ticket.PrevHandler = user;
            EventType mailEvent;

            ticket.TicketingHead = await _helperClass.GetTicketingHead(ticket);

            if (ticket.Type == "service")
            {
                ticket.CurrentHandler = null;
                 mailEvent = EventType.SeekSupervisorApproval;
                ticket.ApprovalRequired = true;
                ticket.Status = "Ticket Submitted - Seeking Department Head's Approval";
                message = $"{user.EmpName} is asking for you approval to raise a service ticket for {ticket.Department} ";
              
            }
            else
            {
                ticket.CurrentHandler = null;
                mailEvent = EventType.SeekHigherAuthorityApproval;
                ticket.ApprovalRequired = false;
                ticket.Status = "Ticket Submitted";
                message = $"{user.EmpName} has raised a ticket for {ticket.Department} ";

            }

            ticket.RequestDate = _helperClass.GetCurrentTime();



            var action = await  _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.TicketRaised, file:fileNames); 
            
            ticket.Actions.Add(action);


            var subordinates = await _teamsService.GetConcernedUsers(ticket.Department);

            foreach (var subordinate in subordinates)
            {
                _notifier.InsertNotification(action.Time, message, user, subordinate.User, ticket.Id);
                ticket.Users.Add(subordinate.User.MailAddress);

            }


            await _ticketsService.CreateAsync(ticket);






            /*        _ticketMailer.SendMail(user, ticket.CurrentHandler, ticket.Department, mailEvent, ticket.Id, user);*/



       


            



            return Ok(true);
          


        }



        [HttpPost]
        [Route("supervisorApprove")]
        public async Task<IActionResult> SupervisorApprove(IFormCollection data)
        {
            var result = await _helperClass.GetContent(data);
            var user = result.user;
            var ticket = result.ticket;
            var comment = result.comment;
            var files = result.fileNames;

            ticket.PrevHandler = user;
            ticket.CurrentHandler = ticket.TicketingHead;
            ticket.Files = files;
            ticket.ApprovalRequired = false;

            ticket.Status = "Ticket Submitted - Department Head's Approval Given";
            ticket.MadeCloseRequest = false;

            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.SupervisorApprove);

            ticket.Actions.Add(action);

            await _ticketsService.UpdateAsync(ticket.Id, ticket);


            var message = $"{user.EmpName} has approved a ticket to be raised for {ticket.Department}";

            _notifier.InsertNotification(action.Time, message, user, ticket.CurrentHandler, ticket.Id);

            _ticketMailer.SendMail(user, ticket.CurrentHandler, ticket.Department, EventType.SeekTicketingHeadApproval, ticket.Id, user);

            
            
            
            return Ok(true);

        }



        [HttpPost]
        [Route("askApproval")]
        public async Task<IActionResult> SeekHigherApproval(IFormCollection data)
        {
            var result = await _helperClass.GetContent(data);
            var user = result.user;
            var ticket = result.ticket;
            var comment = result.comment;
            var approver = JsonSerializer.Deserialize<User>(data["approver"]);
            
            ticket.PrevHandler = user;
            ticket.CurrentHandler = approver;
            ticket.MadeCloseRequest = false;
            ticket.Status = "Ticket Submitted - Seeking Additional Approval";
            ticket.ApprovalRequired = true;
          
            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.SeekingHigherApproval);
            ticket.Actions.Add(action);

            await _ticketsService.UpdateAsync(ticket.Id, ticket);
           
            var message = $"{user.EmpName} is seeking your approval to deal with a ticket raised for {ticket.Department}";

            _notifier.InsertNotification(action.Time, message, user, ticket.CurrentHandler, ticket.Id);


            _ticketMailer.SendMail(user, ticket.CurrentHandler, ticket.Department, EventType.SeekHigherAuthorityApproval, ticket.Id, user);

            return Ok(true);

        }








        [HttpPost]
        [Route("higherApprove")]
        public async Task<IActionResult> HigherApprove(IFormCollection data)
        {
            var result = await _helperClass.GetContent(data);
            var user = result.user;
            var ticket = result.ticket;
            var comment = result.comment;
            var fileNames = result.fileNames;

            ticket.Status = "Ticket Submitted - Additional Approval Given";
            ticket.CurrentHandler = ticket.PrevHandler;
            ticket.PrevHandler = user;

            ticket.ApprovalRequired = false;
          
          
            ticket.MadeCloseRequest = false;
            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.HigherApprove, file:fileNames);
            ticket.Actions.Add(action);
            await _ticketsService.UpdateAsync(ticket.Id, ticket);
          

            var message = $"{user.EmpName} has approved the ticket raised for {ticket.Department}";

            _notifier.InsertNotification(action.Time, message, user, ticket.CurrentHandler, ticket.Id);


            _ticketMailer.SendMail(user, ticket.CurrentHandler, ticket.Department, EventType.HigherAuthorityApproved, ticket.Id, user);
            return Ok(true);

            

        }




        

        [HttpPost]
        [Route("assignSelf")]
        public async Task<IActionResult> AssignSelf(IFormCollection data)
        {

            var user = JsonSerializer.Deserialize<User>(data["user"]);
            var ticket = JsonSerializer.Deserialize<Tickets>(data["ticket"]);
            var comment = data["comment"];


            await _usersService.UpdateUserNumber(user);
            ticket.Assigned = true;
            ticket.AssignedTo = user;
            ticket.PrevHandler = ticket.CurrentHandler;
            ticket.CurrentHandler = ticket.AssignedTo;
            ticket.Accepted = true;
            ticket.Status = "Open";
            ticket.MadeCloseRequest = false;
            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.AssignSelf);
            ticket.Actions.Add(action);
            await _ticketsService.UpdateAsync(ticket.Id, ticket);
             _ticketMailer.SendMail(user, ticket.CurrentHandler, ticket.Department, EventType.AssignSelf, ticket.Id, user);
            return Ok(ticket);


        }





        [HttpPost]
        [Route("assign")]
        public async Task<IActionResult> AssignOther(IFormCollection data)
        {

            var ticket = JsonSerializer.Deserialize<Tickets>(data["ticket"]);
            
            var approver = JsonSerializer.Deserialize<User>(data["approver"]);
            var comment = data["comment"];
            var user = JsonSerializer.Deserialize<User>(data["user"]);

            await _usersService.UpdateUserNumber(approver);
            ticket.PrevHandler = user;
            ticket.CurrentHandler = approver;
            ticket.Assigned = true;
            ticket.AssignedTo = approver;
            ticket.MadeCloseRequest = false;
            ticket.Status = "Assigned / Pending";
            ticket.Accepted = false;
            Console.WriteLine("this is the currentHandler and the ticket");
            Console.WriteLine(ticket.CurrentHandler.ToString());
            Console.WriteLine(approver.ToString());
            Console.WriteLine(ticket.Id);
            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.AssignOther);
            ticket.Actions.Add(action);
            await _ticketsService.UpdateAsync(ticket.Id, ticket);


            var message = $"{user.EmpName} has assigned you the ticket raised for {ticket.Department} by {ticket.RaisedBy.EmpName}";

            _notifier.InsertNotification(action.Time, message, user, ticket.CurrentHandler, ticket.Id);

            _ticketMailer.SendMail(user, ticket.CurrentHandler, ticket.Department, EventType.Assign, ticket.Id, user);
            return Ok(true);



        }

        [HttpPost]
        [Route("unassign")]
        public async Task<IActionResult> Unassign(IFormCollection data)
        {

            var ticket = JsonSerializer.Deserialize<Tickets>(data["ticket"]);

            var prevassignee = JsonSerializer.Deserialize<User>(data["prevAssignee"]);
            var comment = data["comment"];
            var user = JsonSerializer.Deserialize<User>(data["user"]);

           
            ticket.PrevHandler = prevassignee;
            ticket.CurrentHandler = null;
            ticket.Assigned = false;
            ticket.AssignedTo = null;
            ticket.MadeCloseRequest = false;
            ticket.Status = "Ticket Submitted";
            ticket.Accepted = false;
        
            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.Unassigned);
            ticket.Actions.Add(action);
            await _ticketsService.UpdateAsync(ticket.Id, ticket);


            var message = $"{user.EmpName} has unassigned a ticket from you which was raised for {ticket.Department} by {ticket.RaisedBy.EmpName}";

            _notifier.InsertNotification(action.Time, message, user, prevassignee, ticket.Id);

          
            return Ok(true);



        }







        [HttpPost]
        [Route("reassign")]
        public async Task<IActionResult> Reassign(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);
            var ticket = JsonSerializer.Deserialize<Tickets>(data["ticket"]);
            var approver = JsonSerializer.Deserialize<User>(data["approver"]);
            var comment = data["comment"];

            ticket.PrevHandler = ticket.CurrentHandler;
            ticket.CurrentHandler = approver;
            ticket.Assigned = true;
            ticket.AssignedTo = approver;
            ticket.MadeCloseRequest = false;
            ticket.Status = "Assigned / Pending";
            ticket.Accepted = false;
            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.AssignOther);
            ticket.Actions.Add(action);
            await _ticketsService.UpdateAsync(ticket.Id, ticket);

            var message = $"{user.EmpName} has assigned you the ticket raised for {ticket.Department} by {ticket.RaisedBy.EmpName}";

            _notifier.InsertNotification(action.Time, message, user, ticket.CurrentHandler, ticket.Id);

            _ticketMailer.SendMail(user, ticket.CurrentHandler, ticket.Department, EventType.Assign, ticket.Id, user);
            return Ok(true);


        }



        [HttpPost]
        [Route("askInfo")]
        public async Task<IActionResult> AskInfo(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);
            var comment = data["comment"];
            var ticket = JsonSerializer.Deserialize<Tickets>(data["ticket"]);
            var informer = JsonSerializer.Deserialize<User>(data["approver"]);
            Console.Write("this is the id");
            Console.Write(ticket.CurrentHandler.MailAddress);



            ticket.PrevHandler = user;
            ticket.CurrentHandler = informer;


            ticket.Ask = true;
            ticket.MadeCloseRequest = false;
            ticket.Status = "Open (Seeking Information...)";
            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.AskInfo);
            ticket.Actions.Add(action);
            await _ticketsService.UpdateAsync(ticket.Id, ticket);

            var message = $"{user.EmpName} is asking for more information regarding a ticket raised for {ticket.Department} by {ticket.RaisedBy.EmpName}";

            _notifier.InsertNotification(action.Time, message, user, ticket.CurrentHandler, ticket.Id);

            _ticketMailer.SendMail(user, ticket.CurrentHandler, ticket.Department, EventType.Ask, ticket.Id, user);
            return Ok(true);


        }


        [HttpPost]
        [Route("giveInfo")]
        public async Task<IActionResult> GiveInfo(IFormCollection data)
        {
            var result = await _helperClass.GetContent(data);
            var ticket = result.ticket;
            var comment = result.comment;
            var user = result.user;
            var filenames = result.fileNames;
            var info = result.info;

            ticket.Ask = false;

            ticket.Status = "Open (Information Sent)";
            ticket.CurrentHandler = ticket.PrevHandler;
            ticket.PrevHandler = user;
            ticket.MadeCloseRequest = false;
            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.GiveInfo, file:filenames, info: info);
            ticket.Actions.Add(action);
            await _ticketsService.UpdateAsync(ticket.Id, ticket);

            var message = $"{user.EmpName} has given you more information regarding the ticket raised for {ticket.Department} ";

            _notifier.InsertNotification(action.Time, message, user, ticket.CurrentHandler, ticket.Id);

            _ticketMailer.SendMail(user, ticket.CurrentHandler, ticket.Department, EventType.Give, ticket.Id, user);
            return Ok(true);

        }



        [HttpPost]
        [Route("closeRequest")]
        public async Task<IActionResult> CloseRequest(IFormCollection data)
        {
            var result = await _helperClass.GetContent(data);
            var user = result.user;
            var ticket = result.ticket;
            var comment = result.comment;
            var filenames = result.fileNames;
            var info = result.info;

            ticket.PrevHandler = ticket.CurrentHandler;
            ticket.CurrentHandler = ticket.RaisedBy;
            ticket.MadeCloseRequest = true;

            ticket.Status = "Close Requested";

            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.CloseRequest, file:filenames, info:info);
            ticket.Actions.Add(action);
            await _ticketsService.UpdateAsync(ticket.Id, ticket);

            var message = $"{user.EmpName} has requested you to close the request you raised for {ticket.Department} ";

            _notifier.InsertNotification(action.Time, message, user, ticket.CurrentHandler, ticket.Id);


            _ticketMailer.SendMail(user, ticket.CurrentHandler, ticket.Department, EventType.CloseRequest, ticket.Id, user);
            return Ok(true);
        }




        [HttpPost]
        [Route("closeTicket")]
        public async Task<IActionResult> CloseTicket(IFormCollection data)
        {
            var result = await _helperClass.GetContent(data);
            var user = result.user;
            var ticket = result.ticket;
            var comment = result.comment;
            var rating = data["rating"];
            

            ticket.PrevHandler = ticket.CurrentHandler;
            ticket.CurrentHandler = null;

            ticket.Status = "Closed Ticket";
            ticket.MadeCloseRequest = false;

            if (ticket.AssignedTo != null)
            {
                var handler = await _usersService.GetOneUser(ticket.AssignedTo.Id);
                var prevRating = handler.Rating;
                var prevRaters = handler.Raters;
                var newRating = int.Parse(rating);
                var newRaters = prevRaters + 1;
                var currentAvgRating = ((prevRaters * prevRating) + newRating) / newRaters;
                handler.Rating = currentAvgRating;
                handler.Raters = newRaters;

                _usersService.UpdateAsync(handler.Id, handler);

            }

           
            

            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.CloseRequestAccept);
            ticket.Actions.Add(action);
            await _ticketsService.UpdateAsync(ticket.Id, ticket);
            _ticketMailer.SendMail(user, ticket.RaisedBy, ticket.Department, EventType.CloseRequestAccept, ticket.Id, user);
            return Ok(true);
        }





        [HttpPost]
        [Route("closeRequestReject")]
        public async Task<IActionResult> CloseRequestReject(IFormCollection data)
        {
            var result = await _helperClass.GetContent(data);
            var user = result.user;
            var ticket = result.ticket;
            var comment = result.comment;
            var info = result.info;
            

            ticket.PrevHandler = ticket.CurrentHandler;
            ticket.CurrentHandler = ticket.AssignedTo;

            ticket.Status = "Open";
            ticket.MadeCloseRequest = false;

            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.CurrentHandler, comment, ActionType.CloseRequestReject, info:info);
            ticket.Actions.Add(action);
            await _ticketsService.UpdateAsync(ticket.Id, ticket);

            var message = $"{user.EmpName} has rejected your close request for the ticket he raised for {ticket.Department} ";

            _notifier.InsertNotification(action.Time, message, user, ticket.CurrentHandler, ticket.Id);

            _ticketMailer.SendMail(user, ticket.CurrentHandler, ticket.Department, EventType.CloseRequestReject, ticket.Id, user);
            return Ok(true);
        }




        [HttpPost]
        [Route("rejectTicket")]
        public async Task<IActionResult> RejectTicket(IFormCollection data)
        {
            var result = await _helperClass.GetContent(data);
            var user = result.user;
            var ticket = result.ticket;
            var comment = result.comment;
            


            ticket.PrevHandler = ticket.CurrentHandler;
            ticket.CurrentHandler = null;

            ticket.Status = "Rejected";

            ticket.MadeCloseRequest = false;

            var action = await _helperClass.GetAction(ticket.Actions, user, ticket.RaisedBy, comment, ActionType.Reject);
            ticket.Actions.Add(action);
            await _ticketsService.UpdateAsync(ticket.Id, ticket);


            var message = $"{user.EmpName} has rejected the ticket you raised for {ticket.Department}";

            _notifier.InsertNotification(action.Time, message, user, ticket.RaisedBy, ticket.Id);
            _ticketMailer.SendMail(user, ticket.RaisedBy, ticket.Department, EventType.Rejected, ticket.Id, user);
            return Ok(true);
        }


        [HttpPost]
        [Route("getTickets")]
        public async Task<IActionResult> GetTickets(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);

            var result =await _ticketsService.GetTicketsForHandler(user);

       
            return Ok(result);


        }


        [HttpPost]
        [Route("getTicket")]
        public async Task<IActionResult> GetTicket(IFormCollection data)
        {
            var id = data["id"];

            var result = await _ticketsService.GetAsync(id);

            return Ok(result);


        }


        

        [HttpPost]
        [Route("getAllTickets")]
        public async Task<IActionResult> GetAllTickets()
        {


            var result = await _ticketsService.GetAllTickets();

            return Ok(result);


        }

        [HttpPost]
        [Route("getDepartmentTickets")]
        public async Task<IActionResult> GetDepartmentTickets(IFormCollection data)
        {
            var results = await _ticketsService.GetDepartmentTickets(data["user"]);
            return Ok(results);
        }

        

        [HttpPost]
        [Route("getTicketsRaisedByUser")]
        public async Task<IActionResult> GetTicketsRaisedByUser(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);
            var results = await _ticketsService.GetTicketsRaisedByUser(user);
            return Ok(results);
        }


        [HttpPost]
        [Route("setPriority")]
        public async Task<IActionResult> SetPriority(IFormCollection data)
        {
            var results = await _ticketsService.GetAsync(data["id"]);
            results.Priority = data["priority"];
            await _ticketsService.UpdateAsync(data["id"], results);
            return Ok(results.Priority);
        }


        [HttpPost]
        [Route("getTicketsForLeader")]
        public async Task<IActionResult> GetTicketsForLeader(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);
            var results = await _ticketsService.GetTicketsForLeader(user);
            return Ok(results);
           
        }

        [HttpPost]
        [Route("getTicketsForNormal")]
        public async Task<IActionResult> GetTicketsForNormal(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);
            var results = await _ticketsService.GetTicketsForNormal(user);
            return Ok(results);

        }

        [HttpPost]
        [Route("getTicketsForSupport")]
        public async Task<IActionResult> GetTicketsForSupport(IFormCollection data)
        {
            var user = JsonSerializer.Deserialize<User>(data["user"]);
            var results = await _ticketsService.GetTicketsForSupport(user);
            return Ok(results);
        
        }





    }
}
