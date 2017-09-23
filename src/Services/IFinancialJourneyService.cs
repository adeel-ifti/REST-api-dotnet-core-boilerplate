using System;
using System.Threading;
using System.Threading.Tasks;
using AlphaCompanyWebApi.Models;

namespace AlphaCompanyWebApi.Services
{
    public interface IFinancialJourneyService
    {
        Task<ConversationResource> GetConversationAsync(Guid id, CancellationToken ct);

        Task<Page<ConversationResource>> GetConversationsAsync(
            PagingOptions pagingOptions,
            CancellationToken ct);
    }
}
