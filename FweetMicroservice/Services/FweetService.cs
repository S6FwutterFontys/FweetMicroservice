using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FweetMicroservice.Entities;
using FweetMicroservice.Exceptions;
using FweetMicroservice.Models;
using FweetMicroservice.Repositories;

namespace FweetMicroservice.Services
{
    public class FweetService : IFweetService
    {
        private readonly IFweetRepository _repository;

        public FweetService(IFweetRepository repository)
        {
            _repository = repository;
        }

        public async Task<Fweet> GetFweet(Guid fweetId) =>
            await _repository.GetFweet(fweetId);

        public async Task<List<Fweet>> GetFweetsByUserId(Guid userId) =>
            await _repository.GetFweetsByUserId(userId);
        
        public async Task<List<Fweet>> GetAllFweets()
        {
            var sortedFweets = await _repository.GetAllFweets();
            sortedFweets.Sort((x, y) => DateTime.Compare(y.Timestamp, x.Timestamp)); 
            return sortedFweets;
        }

        public async Task<Fweet> PlaceFweet(CreateFweetModel createFweetModel)
        {
            var fweet = new Fweet
            {
                FweetId = Guid.NewGuid(),
                UserId = createFweetModel.UserId,
                Username = createFweetModel.Username,
                FweetMessage = createFweetModel.FweetMessage,
                Timestamp = DateTime.Now,
                Likes = new List<Like>()
            };
            return await _repository.PlaceFweet(fweet);
        }

        public async Task DeleteFweet(Guid userId, Guid fweetId)
        {
            throw new NotImplementedException();
        }

        public async Task<Fweet> UpdateFweet(Guid fweetId, UpdateFweetModdel updatedFweet)
        {
            throw new NotImplementedException();
        }

        public async Task<Fweet> LikeFweet(LikeFweetModel fweet)
        {
            var fweetToLike = await _repository.GetFweet(fweet.FweetId);
            
            if (fweetToLike.Likes == null)
            {
                fweetToLike.Likes = new List<Like>();
            }

            fweetToLike.Likes.Add(new Like { UserId = fweet.UserId, Username = fweet.Username });
            return await _repository.UpdateFweet(fweet.FweetId, fweetToLike);
        }

        public async Task<Fweet> RemoveLikeFweet(LikeFweetModel fweet)
        {
            var fweetToUnlike = await _repository.GetFweet(fweet.FweetId);
            var like = fweetToUnlike.Likes.SingleOrDefault(x => x.UserId == fweet.FweetId);
            
            if (like == null)
            {
                throw new LikeNotFoundException();
            }
            
            fweetToUnlike.Likes.Remove(like);
            return await _repository.UpdateFweet(fweet.FweetId, fweetToUnlike);
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