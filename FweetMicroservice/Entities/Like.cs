using System;

namespace FweetMicroservice.Entities
{
    public class Like
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
    }
}