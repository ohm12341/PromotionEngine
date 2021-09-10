using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using PE.Application.Interfaces;
using PE.Domain.Promotions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class PromotionRepositoryAsync :  GenericRepositoryAsync<Promotion>, IPromotionRepositoryAsync
    {
        private readonly DbSet<Promotion> _promotions;

        public PromotionRepositoryAsync(PromotionDbContext dbContext) : base(dbContext)
        {
            _promotions = dbContext.Set<Promotion>();
        }

        public async Task<Promotion> GetPromotionsAllWithAllRelatedProperties(int Id)
        {
            return (await _promotions.Include(x => x.PromotionSkuCounts).ToListAsync()).FirstOrDefault(x => x.Id == Id);
        }
    }
}
