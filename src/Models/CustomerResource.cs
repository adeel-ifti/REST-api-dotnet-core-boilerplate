using System;

namespace AlphaCompanyWebApi.Models
{
    public sealed class CustomerResource : Resource
    {
        public Link Conversation { get; set; }

        // TODO
        // public Link Author {get;set;}

        public string Body { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
