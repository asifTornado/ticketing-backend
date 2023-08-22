using Eapproval.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Eapproval.services;

public class BlogsService
{

    private readonly IMongoCollection<Blogs> _blogs;

    public BlogsService()
    {
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var mongoDatabase = mongoClient.GetDatabase("eapproval");
        _blogs = mongoDatabase.GetCollection<Blogs>("blogs");
        CreateTextIndexesIfNotExist();
    }

    public async Task<Blogs> GetBlog(string id)
    {
        var result = await _blogs.Find(blog => blog.Id == id).FirstOrDefaultAsync();
        return result;
    }

    public async Task<List<Blogs>> GetAllBlogs()
    {
        var result = await _blogs.Find(_ => true).ToListAsync();
        return result;
    }


    public async Task<List<Blogs>> GetBlogsForUser(User user)
    {
        var result = await _blogs.Find(blog => blog.Authors.Id == user.Id ).ToListAsync();
        return result;
    }


    public async Task InsertBlog(Blogs blog)
    {
        await _blogs.InsertOneAsync(blog);
    }


    public async Task DeleteBlog(string id)
    {
        await _blogs.DeleteOneAsync(item => item.Id == id);
    }


    public async Task EditBlog(Blogs blog)
    {
        await _blogs.ReplaceOneAsync(item => item.Id == blog.Id, blog);
    }


    public async Task<List<Blogs>> GetFilteredBlogs(string searchTerm)
    {
        var filter = Builders<Blogs>.Filter.Text(searchTerm);
        var result  = await _blogs.Find(filter).ToListAsync();
        return result;
    }


    public async Task<List<Blogs>> GetFilteredBlogsForUser(string searchTerm, User user)
    {
        var filter = Builders<Blogs>.Filter.Text(searchTerm) & Builders<Blogs>.Filter.Eq( p => p.Authors.MailAddress, user.MailAddress);
        var result = await _blogs.Find(filter).ToListAsync();
        return result;
    }




    private void CreateTextIndexesIfNotExist()
    {
        var indexes = _blogs.Indexes.List().ToList();

        if (!indexes.Any(index => index.Contains("content")))
        {
            var keys = Builders<Blogs>.IndexKeys.Text(p => p.Content);
            var indexModel = new CreateIndexModel<Blogs>(keys);
            _blogs.Indexes.CreateOne(indexModel);
        }

      /*  if (!indexes.Any(index => index.Contains("headline")))
        {
            var keys = Builders<Blogs>.IndexKeys.Text(p => p.Headline);
            var indexModel = new CreateIndexModel<Blogs>(keys);
            _blogs.Indexes.CreateOne(indexModel);
        }*/


     /*   if (!indexes.Any(index => index.Contains("authors")))
        {
            var keys = Builders<Blogs>.IndexKeys.Text(p => p.Authors);
            var indexModel = new CreateIndexModel<Blogs>(keys);
            _blogs.Indexes.CreateOne(indexModel);
        }*/
    }




}