using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AlphaCompanyWebApi.Models;
using Microsoft.EntityFrameworkCore;
using AlphaCompanyWebApi.Entitites;

namespace AlphaCompanyWebApi.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly ApiDbContext _context;

        public CustomerService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerResource> GetCommentAsync(Guid id, CancellationToken ct)
        {
            var entity = await _context
                .Comments
                .SingleOrDefaultAsync(x => x.Id == id, ct);

            return Mapper.Map<CustomerResource>(entity);
        }

        public async Task<Page<CustomerResource>> GetCommentsAsync(
            Guid? conversationId,
            PagingOptions pagingOptions,
            CancellationToken ct)
        {
            IQueryable<CustomerEntity> query = _context.Comments;

            if (conversationId != null)
            {
                query = query.Where(x => x.Conversation.Id == conversationId);
            }

            // todo apply search
            // todo apply sort

            var size = await query.CountAsync(ct);

            var items = await query
                .Skip(pagingOptions.Offset.Value)
                .Take(pagingOptions.Limit.Value)
                .ProjectTo<CustomerResource>()
                .ToArrayAsync(ct);

            return new Page<CustomerResource>
            {
                Items = items,
                TotalSize = size
            };
        }
    }
}

