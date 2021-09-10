using Microsoft.EntityFrameworkCore;
using PE.Application.Interfaces;
using PE.Domain.BoundedContext.Product.Entities;
using PE.Domain.Cart.Entities;
using PE.Domain.Common;
using PE.Domain.Promotions.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class PromotionDbContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<PromotionSkuCount> PromotionSkuCount { get; set; }

        private readonly IDateTimeService _dateTime;
        public PromotionDbContext(DbContextOptions<PromotionDbContext> options, IDateTimeService dateTime) : base(options)
        {
            _dateTime = dateTime;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntityWithAudit>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;

                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;

                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //All Decimals will have 18,6 Range
            builder.Entity<Product>().HasOne(x => x.Cart).WithMany(x => x.Products).HasForeignKey(x => x.CartID);

            builder.Entity<Promotion>().HasOne(x => x.Product).WithMany(x => x.Promotions).HasForeignKey(x => x.ProductId);

            builder.Entity<PromotionSkuCount>().HasOne(x => x.Promotion).WithMany(x => x.PromotionSkuCounts).HasForeignKey(x => x.PromotionId);


            base.OnModelCreating(builder);
        }
    }
}
