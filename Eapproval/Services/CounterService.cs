using Eapproval.Models;
using MongoDB.Driver;

namespace Eapproval.Services
{
    public class CounterService
    {
        private readonly IMongoCollection<Counter> _counter;
        private readonly string Id ;


        public CounterService()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("eapproval");
            _counter = mongoDatabase.GetCollection<Counter>("counter");
            Id = "64db3d107009062c716b3156";
        }

     

        public async Task<int> GetOrCreateCounterAsync()
        {
            var existingCounter = await _counter.Find(d => d.Id == Id).FirstOrDefaultAsync();

            if (existingCounter != null)
            {
                existingCounter.Count++;

                await _counter.ReplaceOneAsync(x => x.Id == Id, existingCounter);
                
                return existingCounter.Count;

                
            }

            var newCounter = new Counter
            {
                Id = Id,
                Count = 0,
                // Set other properties
            };

            newCounter.Count++;

            await _counter.InsertOneAsync(newCounter);

            return newCounter.Count;
        }

    }
}
