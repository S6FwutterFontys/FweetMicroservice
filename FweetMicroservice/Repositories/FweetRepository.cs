using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FweetMicroservice.DatastoreSettings;
using FweetMicroservice.Entities;
using FweetMicroservice.Models;
using MongoDB.Driver;

namespace FweetMicroservice.Repositories
{
    public class FweetRepository : IFweetRepository 
    {
        
        private readonly IMongoCollection<Fweet> _fweets;

        public FweetRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            
            _fweets = database.GetCollection<Fweet>(settings.CollectionName);
        }

        public async Task<Fweet> GetFweet(Guid fweetId) =>
            await _fweets.Find(f => f.FweetId == fweetId).FirstOrDefaultAsync();

        public async Task<List<Fweet>> GetAllFweets() =>
            await _fweets.Find(fweet => true).ToListAsync();

        public async Task<List<Fweet>> GetFweetsByUserId(Guid userId) =>
            await _fweets.Find(fweet => fweet.UserId == userId).ToListAsync();

        public async Task<Fweet> PlaceFweet(Fweet newFweet)
        {
            await _fweets.InsertOneAsync(newFweet);
            return newFweet;
        }

        public async Task DeleteFweet(Guid fweetId) =>
            await _fweets.DeleteOneAsync(x => x.FweetId == fweetId);

        public async Task<Fweet> UpdateFweet(Guid fweetId, Fweet updatedFweet)
        {
            await _fweets.ReplaceOneAsync(f => f.FweetId == fweetId, updatedFweet);
            return updatedFweet;
        }

        public async Task<Fweet> LikeFweet(LikeFweetModel fweet)
        {
            throw new NotImplementedException();
        }

        public async Task<Fweet> RemoveLikeFweet(LikeFweetModel fweet)
        {
            throw new NotImplementedException();
        }

        public async Task FollowUser(Guid userId, Guid toFollowUserId)
        {
            throw new NotImplementedException();
        }

        public async Task UnfollowUser(Guid userId, Guid toUnfollowUserId)
        {
            throw new NotImplementedException();
        }
    }
}