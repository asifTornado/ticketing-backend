using Eapproval.Models;
using MongoDB.Driver;

namespace Eapproval.Services
{
    public class LocationService
    {

        private readonly IMongoCollection<Location> _locations;

        public LocationService()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("eapproval");
            _locations = mongoDatabase.GetCollection<Location>("locations");
        }


        public async Task<List<Location>> GetAllLocations() =>
        await _locations.Find(_ => true).ToListAsync();


        public async Task AddLocation(Location location)
        {
            await _locations.InsertOneAsync(location);
        }


        public async Task DeleteLocation(string id)
        {
            await _locations.DeleteOneAsync(x => x.Id == id);
        }






    }
}
