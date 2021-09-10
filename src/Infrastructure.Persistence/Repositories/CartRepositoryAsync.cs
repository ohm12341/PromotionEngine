﻿using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using PE.Application.Interfaces;
using PE.Domain.Cart.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class CartRepositoryAsync : GenericRepositoryAsync<Cart>, ICartRepositoryAsync
    {

        private readonly DbSet<Cart> _carts;

        public CartRepositoryAsync(PromotionDbContext dbContext) : base(dbContext)
        {
            _carts = dbContext.Set<Cart>();
        }
        public async Task<Cart> GetCartAllWithAllRelatedProperties(int Id)
        {
            return await _carts.FindAsync(Id);
        }
    }
}
