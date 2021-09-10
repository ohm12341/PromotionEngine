using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using PE.Domain.BoundedContext.Product.Entities;
using PE.Domain.Cart.Entities;
using PE.Domain.Promotions.Entities;
using PE.Domain.Promotions.Enums;
using System;
using MockQueryable.Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.UnitTest
{
    public class RepositoryTests
    {
        [Fact]
        public async Task getall_cart_entity_test()
        {


            var mockSet = GetDummyData().AsQueryable().BuildMockDbSet();

       
            DbContextOptions<PromotionDbContext> options = new DbContextOptions<PromotionDbContext>();
            var mockDateService = new Mock<DateTimeService>();
            var mockContext = new Mock<PromotionDbContext>(options,mockDateService.Object);
            
            mockContext.Setup(m => m.Set<Cart>()).Returns(mockSet.Object);

            var repository = new GenericRepositoryAsync<Cart>(mockContext.Object);

            var carts = await repository.GetAllAsync();

            Assert.NotNull(carts);
            Assert.Equal(1, (await mockSet.Object.ToListAsync()).Count());

        }

        private List<Cart> GetDummyData()
        {
            var cart = new Cart()
            {
                Id = 1,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",

            };
            var product1 = new Product()
            {
                Id = 1,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                SKU = "A",
                Price = 50,
                CartID = 1

            };
            var product2 = new Product()
            {
                Id = 2,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                SKU = "B",
                Price = 30,
                CartID = 1
            };
            var product3 = new Product()
            {
                Id = 3,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                SKU = "C",
                Price = 20,
                CartID = 1

            };
            var product4 = new Product()
            {
                Id = 4,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                SKU = "D",
                Price = 15,
                CartID = 1

            };

            var promotionSkucount1 = new PromotionSkuCount()
            {
                Id = 1,
                Count = 3,
                productId = 1,
                PromotionId = 1
            };
            var promotionSkucount2 = new PromotionSkuCount()
            {
                Id = 2,
                Count = 2,
                productId = 2,
                PromotionId = 2
            };

            var promotionSkucount3 = new PromotionSkuCount()
            {
                Id = 3,
                Count = 1,
                productId = 3,
                PromotionId = 3
            };


            var promotionSkucount4 = new PromotionSkuCount()
            {
                Id = 4,
                Count = 1,
                productId = 4,
                PromotionId = 3
            };



            var promotion1 = new Promotion()
            {
                Id = 1,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                PromotionAmount = 130,
                PromotionType = PromotionType.AssignedToSingleSkus,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 3,
                Name = "3's of X for Y amount",
                PromotionTypeId = 1,

            };
            var promotion2 = new Promotion()
            {
                Id = 2,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                PromotionAmount = 45,
                PromotionType = PromotionType.AssignedToSingleSkus,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 3,
                Name = "2's of X for Y amount",
                PromotionTypeId = 1,

            };
            var promotion3 = new Promotion()
            {
                Id = 3,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                PromotionAmount = 45,
                PromotionType = PromotionType.AssignedToMultipleSkus,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 3,
                Name = "X & Y for Z Amount",
                PromotionTypeId = 1,
                PromotionSkuCounts = new List<PromotionSkuCount>()
                {
                }
            };
            return  new List<Cart>() { cart };
        }
    }
}
