using AlphaCompanyWebApi.Models;
using AlphaCompanyWebApi.Entitites;
using Microsoft.EntityFrameworkCore;

namespace AlphaCompanyWebApi
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<ConversationEntity> Conversations { get; set; }

        public DbSet<CustomerEntity> Comments { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
