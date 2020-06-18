using System;

namespace FweetMicroservice.Models
{
    public class LikeFweetModel
    {        
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public Guid FweetId { get; set; }
        
    }
}