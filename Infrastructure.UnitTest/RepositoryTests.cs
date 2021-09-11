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


            var mockSet = GetCartDummyData().AsQueryable().BuildMockDbSet();

       
            DbContextOptions<PromotionDbContext> options = new DbContextOptions<PromotionDbContext>();
            var mockDateService = new Mock<DateTimeService>();
            var mockContext = new Mock<PromotionDbContext>(options,mockDateService.Object);
            
            mockContext.Setup(m => m.Set<Cart>()).Returns(mockSet.Object);

            var repository = new GenericRepositoryAsync<Cart>(mockContext.Object);

            var carts = await repository.GetAllAsync();

            Assert.NotNull(carts);
            Assert.Equal((await mockSet.Object.ToListAsync()).Count(), carts.ToList().Count());

        }

        [Fact]
        public async Task getall_cart_withSupported_Properties_entity_test()
        {


            var mockSet = GetCartDummyData().AsQueryable().BuildMockDbSet();


            DbContextOptions<PromotionDbContext> options = new DbContextOptions<PromotionDbContext>();
            var mockDateService = new Mock<DateTimeService>();
            var mockContext = new Mock<PromotionDbContext>(options, mockDateService.Object);

            mockContext.Setup(m => m.Set<Cart>()).Returns(mockSet.Object);

            var repository = new CartRepositoryAsync(mockContext.Object);

            var carts = await repository.GetCartAllWithAllRelatedProperties(1);
            var expectedcart = mockSet.Object.FirstOrDefault(x => x.Id == 1);
            Assert.NotNull(carts);
            Assert.Equal(expectedcart.CartProductCount.Count() , carts.CartProductCount.Count());

        }

        [Fact]
        public async Task getall_product_entity_test()
        {


            var mockSet = GetProductDummyData().AsQueryable().BuildMockDbSet();


            DbContextOptions<PromotionDbContext> options = new DbContextOptions<PromotionDbContext>();
            var mockDateService = new Mock<DateTimeService>();
            var mockContext = new Mock<PromotionDbContext>(options, mockDateService.Object);

            mockContext.Setup(m => m.Set<Product>()).Returns(mockSet.Object);

            var repository = new GenericRepositoryAsync<Product>(mockContext.Object);

            var products = await repository.GetAllAsync();

            Assert.NotNull(products);
            Assert.Equal((await mockSet.Object.ToListAsync()).Count(), products.ToList().Count());

        }

        [Fact]
        public async Task getall_Product_withId_withSupported_Properties_entity_test()
        {


            var mockSet = GetProductDummyData().AsQueryable().BuildMockDbSet();


            DbContextOptions<PromotionDbContext> options = new DbContextOptions<PromotionDbContext>();
            var mockDateService = new Mock<DateTimeService>();
            var mockContext = new Mock<PromotionDbContext>(options, mockDateService.Object);

            mockContext.Setup(m => m.Set<Product>()).Returns(mockSet.Object);

            var repository = new ProductRepositoryAsync(mockContext.Object);

            var product = await repository.GetProductWithAllRelatedProperties(1);
            var expectedproduct = mockSet.Object.FirstOrDefault(x => x.Id == 1);
            
            Assert.NotNull(product);
            Assert.Equal(expectedproduct.Promotions.Count(), product.Promotions.Count());

        }

        [Fact]
        public async Task getall_Product_withSupported_Properties_entity_test()
        {


            var mockSet = GetProductDummyData().AsQueryable().BuildMockDbSet();


            DbContextOptions<PromotionDbContext> options = new DbContextOptions<PromotionDbContext>();
            var mockDateService = new Mock<DateTimeService>();
            var mockContext = new Mock<PromotionDbContext>(options, mockDateService.Object);

            mockContext.Setup(m => m.Set<Product>()).Returns(mockSet.Object);

            var repository = new ProductRepositoryAsync(mockContext.Object);

            var products = await repository.GetProductAllWithAllRelatedProperties();
            

            Assert.NotNull(products);
            Assert.Equal((await mockSet.Object.ToListAsync()).Count(), products.ToList().Count());


        }


        [Fact]
        public async Task getall_Promotions_entity_test()
        {


            var mockSet = GetPromotionsDummyData().AsQueryable().BuildMockDbSet();


            DbContextOptions<PromotionDbContext> options = new DbContextOptions<PromotionDbContext>();
            var mockDateService = new Mock<DateTimeService>();
            var mockContext = new Mock<PromotionDbContext>(options, mockDateService.Object);

            mockContext.Setup(m => m.Set<Promotion>()).Returns(mockSet.Object);

            var repository = new GenericRepositoryAsync<Promotion>(mockContext.Object);

            var promotins = await repository.GetAllAsync();

            Assert.NotNull(promotins);
            Assert.Equal((await mockSet.Object.ToListAsync()).Count(), promotins.ToList().Count());

        }

        [Fact]
        public async Task getall_Promotions_withId_withSupported_Properties_entity_test()
        {


            var mockSet = GetPromotionsDummyData().AsQueryable().BuildMockDbSet();


            DbContextOptions<PromotionDbContext> options = new DbContextOptions<PromotionDbContext>();
            var mockDateService = new Mock<DateTimeService>();
            var mockContext = new Mock<PromotionDbContext>(options, mockDateService.Object);

            mockContext.Setup(m => m.Set<Promotion>()).Returns(mockSet.Object);

            var repository = new PromotionRepositoryAsync(mockContext.Object);

            var promotion = await repository.GetPromotionsAllWithAllRelatedProperties(1);
            var expectedproduct = mockSet.Object.FirstOrDefault(x => x.Id == 1);

            Assert.NotNull(promotion);
            Assert.Equal(expectedproduct.PromotionSkuCounts.Count(), promotion.PromotionSkuCounts.Count());

        }
     

        private List<Cart> GetCartDummyData()
        {
            var cart1 = new Cart()
            {
                Id = 1,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser1",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser1",

            };
            var cart2 = new Cart()
            {
                Id = 2,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser2",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser2",

            };
            
         

            var cartSkucountScenario1_1 = new CartProductCount()
            {
                Id = 1,
                Count = 1,
                productId = 1,
                CartId = 1
            };
            var cartSkucountScenario1_2 = new CartProductCount()
            {
                Id = 2,
                Count = 1,
                productId = 2,
                CartId = 1
            };
          

            var cartSkucountScenario2_1 = new CartProductCount()
            {
                Id = 4,
                Count = 5,
                productId = 1,
                CartId = 2
            };
            var cartSkucountScenario2_2 = new CartProductCount()
            {
                Id = 5,
                Count = 5,
                productId = 2,
                CartId = 2
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
                PromotionTypeId = 1,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 3,
                Name = "3's of X for Y amount",


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
                PromotionTypeId = 1,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 2,
                Name = "2's of X for Y amount",

            };
            var promotion3 = new Promotion()
            {
                Id = 3,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                PromotionAmount = 30,
                PromotionTypeId = 2,
                PromotionType = PromotionType.AssignedToMultipleSkus,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 1,
                Name = "X & Y for Z Amount",

                PromotionSkuCounts = new List<PromotionSkuCount>()
                {
                }
            };
            var promotion4 = new Promotion()
            {
                Id = 4,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                PromotionAmount = 40,
                PromotionTypeId = 2,
                PromotionType = PromotionType.AssignedToMultipleSkus,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 1,
                Name = "X & Y for Z Amount",

                PromotionSkuCounts = new List<PromotionSkuCount>()
                {
                }
            };

            cart1.CartProductCount = new List<CartProductCount>() { cartSkucountScenario1_1, cartSkucountScenario1_2 };
            cart2.CartProductCount = new List<CartProductCount>() { cartSkucountScenario2_1, cartSkucountScenario2_2 };
            return  new List<Cart>() { cart1, cart2 };
        }

        private List<Product> GetProductDummyData()
        {
           



            var product1 = new Product()
            {
                Id = 1,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                SKU = "A",
                Price = 50


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
                PromotionTypeId = 1,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 3,
                Name = "3's of X for Y amount",


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
                PromotionTypeId = 1,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 2,
                Name = "2's of X for Y amount",

            };
            var promotion3 = new Promotion()
            {
                Id = 3,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                PromotionAmount = 30,
                PromotionTypeId = 2,
                PromotionType = PromotionType.AssignedToMultipleSkus,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 1,
                Name = "X & Y for Z Amount",

                PromotionSkuCounts = new List<PromotionSkuCount>()
                {
                }
            };
            var promotion4 = new Promotion()
            {
                Id = 4,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                PromotionAmount = 40,
                PromotionTypeId = 2,
                PromotionType = PromotionType.AssignedToMultipleSkus,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 1,
                Name = "X & Y for Z Amount",

                PromotionSkuCounts = new List<PromotionSkuCount>()
                {
                }
            };

            product1.Promotions = new List<Promotion>() { promotion1 };
            product2.Promotions = new List<Promotion>() { promotion2 };
            return new List<Product>() { product1, product2 };
        }

        private List<Promotion> GetPromotionsDummyData()
        {

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

            var promotion1 = new Promotion()
            {
                Id = 1,
                Created = System.DateTime.Now,
                CreatedBy = "TestUser",
                LastModified = System.DateTime.Now,
                LastModifiedBy = "TestUser",
                PromotionAmount = 130,
                PromotionType = PromotionType.AssignedToSingleSkus,
                PromotionTypeId = 1,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 3,
                Name = "3's of X for Y amount",


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
                PromotionTypeId = 1,
                IsCumulative = false,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(40),
                MinimumPromotionedQuantity = 2,
                Name = "2's of X for Y amount",

            };
           

            promotion1.PromotionSkuCounts = new List<PromotionSkuCount>() { promotionSkucount1 };
            promotion2.PromotionSkuCounts = new List<PromotionSkuCount>() { promotionSkucount2 };
            return new List<Promotion>() { promotion1, promotion2 };
        }
    }
}
