using Eapproval.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;


namespace Eapproval.services;

public class NotesService
{

    private readonly IMongoCollection<Notes> _notes;

    public NotesService()
    {
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var mongoDatabase = mongoClient.GetDatabase("eapproval");
        _notes = mongoDatabase.GetCollection<Notes>("notes");
    }


    public async Task<List<Notes>> GetNotesById(string id) =>
    await _notes.Find(x => x.TicketId == id).ToListAsync();


    public async Task InsertNote(Notes note)
    {
         await _notes.InsertOneAsync(note);
    }



    


}
