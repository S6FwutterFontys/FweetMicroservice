using System;
using System.Threading.Tasks;
using FweetMicroservice.Entities;
using FweetMicroservice.Models;

namespace FweetMicroservice.Services
{
    public class FweetService : IFweetService
    {
        public Task<Fweet> GetFweet(Guid fweetId)
        {
            throw new NotImplementedException();
        }

        public Task<Fweet> PlaceFweet(Fweet fweet)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFweet(Guid userId, Guid fweetId)
        {
            throw new NotImplementedException();
        }

        public Task FollowUser(Guid userId, Guid toFollowUserId)
        {
            throw new NotImplementedException();
        }

        public Task<Fweet> UpdateFweet(Guid fweetId, UpdateFweetModdel updatedFweet)
        {
            throw new NotImplementedException();
        }
    }
}