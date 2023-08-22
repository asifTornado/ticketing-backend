using Eapproval.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace Eapproval.services
{
    public class ConnectionsService
    {
        private ChatService _chatService;
        public ConnectionsService(ChatService chatService) 
        {
        
            _chatService = chatService;
        
        }
     


        public async Task AddConnection(string ticketId, ConnectionHolderClass connectionHolderClass)
        {
            var connection = await _chatService.getChat(ticketId);
            if (connection == null)
            {
                Console.WriteLine("entered first if");
                var newConnection = new Chat();
                newConnection.TicketId = ticketId;
                newConnection.ConnectionHolders.Add(connectionHolderClass);
                await _chatService.insertChat(newConnection);
                return;
            }
            else
            {
                var existingCon = connection.ConnectionHolders.Find(x => x.Id == connectionHolderClass.Id);
                if (existingCon == null)
                {
                    connection.ConnectionHolders.Add(connectionHolderClass);
                }
                await _chatService.UpdateChat(connection.Id, connection);
            }
              
            
        }

        public async Task<Chat> GetConnection(string ticketId)
        {

            var connection = await _chatService.getChat(ticketId);
            return connection;

        }
    }
}