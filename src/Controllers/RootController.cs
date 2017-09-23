using AlphaCompanyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlphaCompanyWebApi.Controllers
{
    [Route("/")]
    public class RootController : Controller
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new RootResource
            {
                Self = Link.To(nameof(GetRoot)),
                Conversations = Link.ToCollection(nameof(FinancialJourneyController.GetConversationsAsync)),
                Comments = Link.ToCollection(nameof(CustomerController.GetCommentsAsync))
            };

            return Ok(response);
        }
    }
}
