using Eapproval.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Org.BouncyCastle.Crypto.Operators;

namespace Eapproval.services;

public class UsersService
{

    private readonly IMongoCollection<User> _user;

    public UsersService()
    {
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var mongoDatabase = mongoClient.GetDatabase("eapproval");
        _user = mongoDatabase.GetCollection<User>("users");
    }


    public async Task<List<User>> GetAsync() =>
    await _user.Find(_ => true).ToListAsync();



    public async Task<User> GetUserByMail(string mail)
    {
        var result = await _user.Find(user => user.MailAddress == mail).FirstOrDefaultAsync();
        return result;
    }


    public async Task<User> GetUserByMailAndPassword(string mail, string password)
    {
        var result = await _user.Find(user => user.MailAddress == mail && user.Password == password).FirstOrDefaultAsync();
        return result;
    }

    public async Task<List<User>> GetAllNormalUsers()
    {
        var result = await _user.Find(user => user.UserType != "Admin" && user.UserType != "Master Admin").ToListAsync();
        return result;
    }


    public async Task<List<User>> GetUsersIncludingAdmin()
    {
        var result = await _user.Find(user => user.UserType != "Master Admin" ).ToListAsync();
        return result;
    }

    public async Task<User?> GetOneUser(string id) =>
        await _user.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(User newTicket) =>
        await _user.InsertOneAsync(newTicket);

    public async Task UpdateAsync(string id, User updatedTicket) =>
        await _user.ReplaceOneAsync(x => x.Id == id, updatedTicket);

    public async Task UpdateUserNumber(User user)
    {
        user.Numbers = user.Numbers + 1;
        await _user.ReplaceOneAsync(x => x.Id == user.Id, user);
    }

    public async Task RemoveAsync(string id) =>
        await _user.DeleteOneAsync(x => x.Id == id);

    public async Task<User?> GetOneUserByGroups(string group) =>
        await _user.Find(x => x.Groups.Contains(group)).FirstOrDefaultAsync();



}
