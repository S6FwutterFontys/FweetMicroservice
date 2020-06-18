using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace FweetMicroservice.Entities
{
    [BsonIgnoreExtraElements]
    public class Fweet
    {
        public Guid FweetId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public DateTime Timestamp { get; set; }
        public string FweetMessage { get; set; }
        public List<Like> Likes { get; set; }
    }
}