using Eapproval.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.IO;


namespace Eapproval.services;

public class ChatService
{

    private readonly IMongoCollection<Chat> _chat;

    public ChatService()
    {
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var mongoDatabase = mongoClient.GetDatabase("eapproval");
        _chat = mongoDatabase.GetCollection<Chat>("chat");
    }
    

    public async Task<List<Chat>> getChats()
    {
        var result = await _chat.Find(_ => true).ToListAsync();
        return result;
    }

    public async Task<Chat> getChat(string id)
    {
        var result = await _chat.Find(x => x.TicketId == id).FirstOrDefaultAsync();
        return result; 
    }

    public async Task insertChat(Chat chat)
    {
        await _chat.InsertOneAsync(chat);
    }


    public async Task UpdateChat(string id, Chat chat)
    {
        await _chat.ReplaceOneAsync(x => x.Id == id, chat);
    }
   



}
