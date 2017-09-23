using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using AlphaCompanyWebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using AlphaCompanyWebApi.Models;
using AlphaCompanyWebApi.Services;

namespace AlphaCompany.Onboarding.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService CustomerService )
        {
            productService = CustomerService;
        }

        [HttpGet]
        [TokenAuthorize]
        public async Task<IActionResult> Get(CancellationToken ct)
        {

            return Ok(productService.GetProductsAsync(ct));
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/values
        [HttpPost]
        [TokenAuthorize]
        public void Post(ActivityModel activity)
        {

            productService.SendMessageToCrmQueue(activity);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
