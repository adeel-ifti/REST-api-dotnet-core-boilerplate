using System;
using Microsoft.AspNetCore.Mvc;

namespace AlphaCompanyWebApi.Controllers
{
    public class GetConversationByIdParameters
    {
        [FromRoute]
        public Guid ConversationId { get; set; }
    }
}