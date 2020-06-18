using System;

namespace FweetMicroservice.Exceptions
{
    public class LikeNotFoundException : Exception
    {
        public LikeNotFoundException() 
            : base("This fweet was not liked by this person.")
        {
        }
    }
}