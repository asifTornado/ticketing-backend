using Eapproval.services;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver.Core.Connections;
using Eapproval.Models;
using System.Text.Json;
using Eapproval.Helpers;
using Eapproval.Services;
using Humanizer;

namespace Eapproval.signalR;

public class ChatHub:Hub
{

    private ChatService _chatService;
    private TicketsService _ticketsService;
    public ConnectionsService _connectionsService;
    private HelperClass _helperClass;
    private FileHandler _fileHandler;
    private NotificationService _notificationsService;

    public ChatHub (NotificationService notificationsService, ChatService chatService, TicketsService ticketsService, ConnectionsService connectionsService, HelperClass helperClass, FileHandler fileHandler)
    {
        _chatService = chatService;
        _ticketsService = ticketsService;
        _connectionsService = connectionsService;
        _helperClass = helperClass;
        _fileHandler = fileHandler;
        _notificationsService = notificationsService;
    }

    public async Task SendMessage(string message, string user, string ticketId)
    {
 

      

        var from = JsonSerializer.Deserialize<User>(user);

        var time = _helperClass.GetCurrentTime();


        var newMessage = new ConversationClass()
        {
            From = from,
            Message = message,
            Time = time,
        };
        var messageString = JsonSerializer.Serialize(newMessage);

        Console.WriteLine(messageString);

        var connection = await _connectionsService.GetConnection(ticketId);
        connection.Conversation.Add(newMessage);
        await _chatService.UpdateChat(connection.Id, connection);

        foreach(var x in connection.ConnectionHolders)
        {
            Console.WriteLine("connections send");
            Console.WriteLine(x);
            await Clients.Client(x.Id).SendAsync("Receive", messageString);
        }

     

    }



    public async Task UploadFile(string files, string user, string ticketId)
    {
        var id = Context.ConnectionId;



        var from = JsonSerializer.Deserialize<User>(user);

        var time = _helperClass.GetCurrentTime();

        var fileNames = JsonSerializer.Deserialize<List<File2>>(files);

        var newMessage = new ConversationClass()
        {
            From = from,
            Message = null,
            Time = time,
            Type = "files",
            Files = fileNames

        };
        var messageString = JsonSerializer.Serialize(newMessage);

        Console.WriteLine(messageString);

        var connection = await _connectionsService.GetConnection(ticketId);
        connection.Conversation.Add(newMessage);
        await _chatService.UpdateChat(connection.Id, connection);

        foreach (var x in connection.ConnectionHolders)
        {
            Console.WriteLine("connections send");
            Console.WriteLine(x);
            await Clients.Client(x.Id).SendAsync("Receive", messageString);
        }

   


    }





    public async Task Subscribe(string ticketId, string name)
    {

        
        var id = Context.ConnectionId;

        var newConnectionHolder = new ConnectionHolderClass()
        {
            Id = id,
            Name = name,
        };

        _connectionsService.AddConnection(ticketId, newConnectionHolder);

     }


    public async Task SendNotificationFromClient(string message, string from, string to, string ticketId)
    {

        var From = new User()
        {
            EmpName = from,
        };

        var To = new User()
        {
            EmpName = to,
        };



        var newNotification = new Notification()
        {
            Time = _helperClass.GetCurrentTime(),
            Message = message,
            From = From,
            To = To,
            TicketId = ticketId,
            Type="chat"
        };

        await _notificationsService.InsertNotification(newNotification); 

        var notificationString = JsonSerializer.Serialize(newNotification);

        var connection = await _connectionsService.GetConnection(ticketId);


        foreach(var x in connection.ConnectionHolders)
        {
            if(x.Name == to)
            {
                Console.WriteLine(x.Name);
                await Clients.Client(x.Id).SendAsync("NotificationReceive", notificationString);
            }
        }


        
    }


    public async Task MakeCall(string name, string TicketId, string callerId)
    {
        var connection = await _connectionsService.GetConnection(TicketId);

        foreach (var x in connection.ConnectionHolders)
        {
            if (x.Name == name)
            {
                Console.WriteLine(x.Name);
                await Clients.Client(x.Id).SendAsync("CallAlert", callerId);
            }
        }


    }




   
    
}
