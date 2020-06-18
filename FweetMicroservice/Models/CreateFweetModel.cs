using System;
using System.ComponentModel.DataAnnotations;

namespace FweetMicroservice.Models
{
    public class CreateFweetModel
    {
        [Required] public Guid UserId { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string FweetMessage { get; set; }
    }
}