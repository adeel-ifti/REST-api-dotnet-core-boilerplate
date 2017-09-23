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
    public class FinancialJourneyController : Controller
    {
        private readonly IFinancialJourneyService _conversationService;
        private readonly ICustomerService _CustomerService;
        private readonly PagingOptions _defaultPagingOptions;

        public FinancialJourneyController(
            IFinancialJourneyService conversationService,
            ICustomerService CustomerService,
            IOptions<PagingOptions> defaultPagingOptionsAccessor)
        {
            _conversationService = conversationService;
            _CustomerService = CustomerService;
            _defaultPagingOptions = defaultPagingOptionsAccessor.Value;
        }

        [HttpGet(Name = nameof(GetConversationsAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetConversationsAsync(
            [FromQuery] PagingOptions pagingOptions,
            CancellationToken ct)
        {
            pagingOptions.Offset = pagingOptions?.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions?.Limit ?? _defaultPagingOptions.Limit;

            var conversations = await _conversationService.GetConversationsAsync(
                pagingOptions, ct);

            var collection = CollectionWithPaging<ConversationResource>.Create(
                Link.ToCollection(nameof(GetConversationsAsync)),
                conversations.Items.ToArray(),
                conversations.TotalSize,
                pagingOptions);

            return Ok(collection);
        }

        [HttpGet("{conversationId}", Name = nameof(GetConversationByIdAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetConversationByIdAsync(GetConversationByIdParameters parameters, CancellationToken ct)
        {
            if (parameters.ConversationId == Guid.Empty) return NotFound();

            var conversation = await _conversationService.GetConversationAsync(parameters.ConversationId, ct);
            if (conversation == null) return NotFound();

            return Ok(conversation);
        }

        [HttpGet("{conversationId}/comments", Name = nameof(GetConversationCommentsByIdAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetConversationCommentsByIdAsync(
            GetConversationByIdParameters parameters,
            [FromQuery] PagingOptions pagingOptions,
            CancellationToken ct)
        {
            pagingOptions.Offset = pagingOptions?.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions?.Limit ?? _defaultPagingOptions.Limit;

            var conversationComments = await _CustomerService.GetCommentsAsync(parameters.ConversationId, pagingOptions, ct);

            var collection = CollectionWithPaging<CustomerResource>.Create(
                Link.ToCollection(
                    nameof(GetConversationCommentsByIdAsync),
                    new GetConversationByIdParameters { ConversationId = parameters.ConversationId }),
                conversationComments.Items.ToArray(),
                conversationComments.TotalSize,
                pagingOptions);

            return Ok(collection);
        }
    }
}
