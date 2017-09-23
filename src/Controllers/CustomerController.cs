using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlphaCompanyWebApi.Infrastructure;
using AlphaCompanyWebApi.Models;
using AlphaCompanyWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AlphaCompanyWebApi.Controllers
{
    [Route("/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _CustomerService;
        private readonly PagingOptions _defaultPagingOptions;

        public CustomerController(
            ICustomerService CustomerService,
            IOptions<PagingOptions> defaultPagingOptionsAccessor)
        {
            _CustomerService = CustomerService;
            _defaultPagingOptions = defaultPagingOptionsAccessor.Value;
        }

        [HttpGet(Name = nameof(GetCommentsAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetCommentsAsync(
            [FromQuery] PagingOptions pagingOptions,
            CancellationToken ct)
        {
            pagingOptions.Offset = pagingOptions.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaultPagingOptions.Limit;

            var conversations = await _CustomerService.GetCommentsAsync(null, pagingOptions, ct);

            var collection = CollectionWithPaging<CustomerResource>.Create(
                Link.ToCollection(nameof(GetCommentsAsync)),
                conversations.Items.ToArray(),
                conversations.TotalSize,
                pagingOptions);

            return Ok(collection);
        }

        [HttpGet("{commentId}", Name = nameof(GetCommentByIdAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetCommentByIdAsync(GetCommentByIdParameters parameters, CancellationToken ct)
        {
            if (parameters.CommentId == Guid.Empty) return NotFound();

            var conversation = await _CustomerService.GetCommentAsync(parameters.CommentId, ct);
            if (conversation == null) return NotFound();

            return Ok(conversation);
        }
    }
}
