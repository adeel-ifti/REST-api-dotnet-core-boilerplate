using System;
using Microsoft.AspNetCore.Mvc;

namespace AlphaCompanyWebApi.Controllers
{
    public class GetCommentByIdParameters
    {
        [FromRoute]
        public Guid CommentId { get; set; }
    }
}