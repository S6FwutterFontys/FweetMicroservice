﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FweetMicroservice.Entities;
using FweetMicroservice.Models;

namespace FweetMicroservice.Services
{
    public interface IFweetService
    {
        Task<Fweet> GetFweet(Guid fweetId);
        Task<List<Fweet>> GetFweetsByUserId(Guid id);
        Task<List<Fweet>> GetAllFweets();
        
        Task<Fweet> PlaceFweet(CreateFweetModel newFweet);
        Task DeleteFweet(Guid userId, Guid fweetId);
        Task<Fweet> UpdateFweet(Guid fweetId, UpdateFweetModdel updatedFweet);
        
        Task<Fweet> LikeFweet(LikeFweetModel fweet);
        Task<Fweet> RemoveLikeFweet(LikeFweetModel fweet);
        
        Task FollowUser(Guid userId, Guid toFollowUserId);
        Task UnfollowUser(Guid userId, Guid toUnfollowUserId);
    }
}