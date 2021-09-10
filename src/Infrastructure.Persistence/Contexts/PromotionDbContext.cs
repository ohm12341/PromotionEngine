using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public class PromotionDbContext : DbContext
    {
        public DbSet<Cart> Products { get; set; }
    }
}
