using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using PE.Application.Interfaces;
using PE.Domain.BoundedContext.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {

        private readonly DbSet<Product> _products;

        public ProductRepositoryAsync(PromotionDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<Product>();
        }

        public async Task<List<Product>> GetProductAllWithAllRelatedProperties()
        {
            return (await _products.Include(x => x.PromotionSkuCounts).Include(x=>x.Promotions).ToListAsync()).ToList();

        }

        public async Task<Product> GetProductAllWithAllRelatedProperties(int Id)
        {
            return (await _products.Include(x => x.PromotionSkuCounts).ToListAsync()).FirstOrDefault(x => x.Id == Id);
           
        }
    }
}
