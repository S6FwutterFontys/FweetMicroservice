using System;

namespace FweetMicroservice.Models
{
    public class UpdateFweetModdel
    {
        public Guid UserId { get; set; }
        public string FweetMessage { get; set; }
    }
}