using System;
using System.ComponentModel.DataAnnotations;

namespace FweetMicroservice.Entities
{
    public class Fweet
    {
        [Required] public Guid FweetId { get; set; }
        [Required] public Guid UserId { get; set; }
        [Required] public long Timestamp { get; set; }
        [Required] public string FweetMessage { get; set; }
    }
}