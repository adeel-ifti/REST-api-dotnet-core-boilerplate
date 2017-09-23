using System;
using System.Threading;
using System.Threading.Tasks;
using AlphaCompanyWebApi.Models;

namespace AlphaCompanyWebApi.Services
{
    public interface ICustomerService
    {
        Task<CustomerResource> GetCommentAsync(Guid id, CancellationToken ct);

        Task<Page<CustomerResource>> GetCommentsAsync(
            Guid? conversationId,
            PagingOptions pagingOptions,
            CancellationToken ct);
    }
}
