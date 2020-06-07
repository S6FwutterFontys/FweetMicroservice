using System;
using System.Threading.Tasks;
using FweetMicroservice.Entities;
using FweetMicroservice.Models;

namespace FweetMicroservice.Services
{
    public interface IFweetService
    {
        Task<Fweet> GetFweet(Guid fweetId);
        Task<Fweet> PlaceFweet(Fweet fweet);
        Task DeleteFweet(Guid userId, Guid fweetId);
        Task FollowUser(Guid userId, Guid toFollowUserId);
        Task<Fweet> UpdateFweet(Guid fweetId, UpdateFweetModdel updatedFweet);
    }
}