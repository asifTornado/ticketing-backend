using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Eapproval.Models;




namespace Eapproval.Helpers;

public enum EventType
{
    SeekSupervisorApproval,
    Rejected,
    SeekTicketingHeadApproval,
    SeekHigherAuthorityApproval,
    CloseRequest,
    CloseRequestAccept,
    CloseRequestReject,
    Ask,
    Give,
    Assign,
    Reassign,
    AssignSelf,
    SupervisorApproved,
    HigherAuthorityApproved
}

public class TicketMailer
{
   

    

    public async Task SendMail(User from, User to, string department, EventType _event, string id, User raiser)
    {
         string body = string.Empty;
         string subject = string.Empty;
         string html = string.Empty;

        Console.WriteLine("Sending Email");

        switch (_event)
        {
            case EventType.SeekSupervisorApproval:
                subject = "A new ticket needs your approval";
                html = $@"
            <p>A new ticket raised by {from.EmpName} for the {department} department requires your approval</p>
            <a href=""http://localhost:5173/ticketing/ticketDetails/{id}"" style='text-decoration: underline; color:dodgerblue'>Check</a>";
                body = html;
                break;

            case EventType.Rejected:
                subject = "Your Request Has been Rejected";
                html = $@"
            <p>{from.EmpName} has rejected the ticket that you raised for the {department} department</p>
            <a href=""http://localhost:5173/ticketing/ticketDetails/{id}"" style='text-decoration: underline; color:dodgerblue'>Check</a>";
                body = html;
                break;

            case EventType.SeekTicketingHeadApproval:
                subject = "A new ticket needs your approval";
                html = $@"
            <p>A new ticket raised by {from.EmpName} for the {department} department requires your approval</p>
            <a href=""http://localhost:5173/ticketing/ticketDetails/{id}"" style='text-decoration: underline; color:dodgerblue'>Check</a>";
                body = html;
                break;

            case EventType.SeekHigherAuthorityApproval:
                subject = "A new ticket needs your approval";
                html = $@"
            <p>A new ticket raised by {from.EmpName} for the {department} department requires your approval</p>
            <a href=""http://localhost:5173/ticketing/ticketDetails/{id}"" style='text-decoration: underline; color:dodgerblue'>Check</a>";
                body = html; 
                break;

            case EventType.CloseRequest:
                subject = "One of your ticket needs to be closed";
                html = $@"
            <p>{from.EmpName} is requesting you to close the ticket that you raised for the {department} department</p>
            <a href=""http://localhost:5173/ticketing/ticketDetails/{id}"" style='text-decoration: underline; color:dodgerblue'>Check</a>";
                body = html; 
                break;

            case EventType.CloseRequestReject:
                subject = "Your ticket close request was rejected";
                html = $@"
            <p>{from.EmpName} has rejected your ticket close request.</p>
            <a href=""http://localhost:5173/ticketing/ticketDetails/{id}"" style='text-decoration: underline; color:dodgerblue'>Check</a>";
                body = html;
                break;

            case EventType.Ask:
                subject = "More information is required for your ticket";
                html = $@"
            <p>{from.EmpName} is requesting more information regarding your ticket.</p>
            <a href=""http://localhost:5173/ticketing/ticketDetails/{id}"" style='text-decoration: underline; color:dodgerblue'>Check</a>";
                body = html; 
                break;

            case EventType.Give:
                subject = "You have received more information regarding a ticket";
                html = $@"
            <p>{from.EmpName} has given you more information regarding their ticket for the {department} department.</p>
            <a href=""http://localhost:5173/ticketing/ticketDetails/{id}"" style='text-decoration: underline; color:dodgerblue'>Check</a>";

                body = html; 
                break;

            case EventType.Assign:
                subject = "You have been assigned a new ticket";
                html = $@"
            <p>{from.EmpName} has assigned you a new ticket from {raiser.EmpName}</p>
            <a href=""http://localhost:5173/ticketing/ticketDetails/{id}"" style='text-decoration: underline; color:dodgerblue'>Check</a>";
                body = html;
                break;

            case EventType.SupervisorApproved:
                subject = "A new ticket has been raised for your team";
                html = $@"
            <p>{from.EmpName} has raised a new ticket</p>
            <a href=""http://localhost:5173/ticketing/ticketDetails/{id}"" style='text-decoration: underline; color:dodgerblue'>Check</a>";

                body = html; 
                break;

            case EventType.HigherAuthorityApproved:
                subject = "A ticket has been approved from higher authority";
                html = $@"
            <p>The ticket from {from.EmpName} has been approved from higher authority</p>
            <a href=""http://localhost:5173/ticketing/ticketDetails/{id}"" style='text-decoration: underline; color:dodgerblue'>Check</a>";
                body = html; 
                break;

            default:
                break;
        }

  
 

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("", senderEmail));
        message.To.Add(new MailboxAddress("", recipientEmail));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.HtmlBody = body;
        message.Body = bodyBuilder.ToMessageBody();

        Console.WriteLine("This is the address from which the email is sent");
        Console.WriteLine(senderEmail);

        using (var client = new SmtpClient())
        {
            Console.WriteLine("Just ending email");
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(senderEmail, senderPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
