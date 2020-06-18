using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FweetMicroservice.Entities;
using FweetMicroservice.Models;

namespace FweetMicroservice.Repositories
{
    public interface IFweetRepository
    {
        Task<Fweet> GetFweet(Guid fweetId);
        Task<List<Fweet>> GetAllFweets();
        Task<List<Fweet>> GetFweetsByUserId(Guid id);
        
        Task<Fweet> PlaceFweet(Fweet newFweet);
        Task DeleteFweet(Guid fweetId);
        Task<Fweet> UpdateFweet(Guid fweetId, Fweet updatedFweet);
        
        Task<Fweet> LikeFweet(LikeFweetModel fweet);
        Task<Fweet> RemoveLikeFweet(LikeFweetModel fweet);
        
        Task FollowUser(Guid userId, Guid toFollowUserId);
        Task UnfollowUser(Guid userId, Guid toUnfollowUserId);
    }
}