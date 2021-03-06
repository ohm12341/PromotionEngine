using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PE.Domain.BoundedContext.Product.Entities;
using PE.Domain.Cart.Entities;
using PE.Domain.Promotions.Entities;
using PE.Domain.Promotions.Enums;
using System.Collections.Generic;

namespace Infrastructure.Persistence.ServiceExtensions
{
    public static class ModelBuilderExtensions
    {
        public static void InitializeSeedData(this IApplicationBuilder app, bool development = false)
        {

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetService<PromotionDbContext>())
            {
                if (development)
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
                    var cart3 = new Cart()
                    {
                        Id = 3,
                        Created = System.DateTime.Now,
                        CreatedBy = "TestUser3",
                        LastModified = System.DateTime.Now,
                        LastModifiedBy = "TestUser3",

                    };

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
                    var cartSkucountScenario1_3 = new CartProductCount()
                    {
                        Id = 3,
                        Count = 1,
                        productId = 3,
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
                    var cartSkucountScenario2_3 = new CartProductCount()
                    {
                        Id = 6,
                        Count = 1,
                        productId = 3,
                        CartId = 2
                    };


                    var cartSkucountScenario3_1 = new CartProductCount()
                    {
                        Id = 7,
                        Count = 3,
                        productId = 1,
                        CartId = 3
                    };
                    var cartSkucountScenario3_2 = new CartProductCount()
                    {
                        Id = 8,
                        Count = 5,
                        productId = 2,
                        CartId = 3
                    };
                    var cartSkucountScenario3_3 = new CartProductCount()
                    {
                        Id = 9,
                        Count = 1,
                        productId = 3,
                        CartId = 3
                    };
                    var cartSkucountScenario3_4 = new CartProductCount()
                    {
                        Id = 10,
                        Count = 1,
                        productId = 4,
                        CartId = 3
                    };


                    var cartSkucountScenario4_1 = new CartProductCount()
                    {
                        Id = 11,
                        Count = 3,
                        productId = 1,
                        CartId = 4
                    };
                    var cartSkucountScenario4_2 = new CartProductCount()
                    {
                        Id = 12,
                        Count = 5,
                        productId = 2,
                        CartId = 4
                    };
                    var cartSkucountScenario4_3 = new CartProductCount()
                    {
                        Id = 13,
                        Count = 3,
                        productId = 3,
                        CartId = 4
                    };
                    var cartSkucountScenario4_4 = new CartProductCount()
                    {
                        Id = 14,
                        Count = 2,
                        productId = 4,
                        CartId = 4
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

                    var promotionSkucount5 = new PromotionSkuCount()
                    {
                        Id = 5,
                        Count = 2,
                        productId = 3,
                        PromotionId = 4
                    };


                    var promotionSkucount6 = new PromotionSkuCount()
                    {
                        Id = 6,
                        Count = 1,
                        productId = 4,
                        PromotionId = 4
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
                        PromotionTypeId=1    ,
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
                        PromotionTypeId=1,
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
                        PromotionTypeId=2,
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

                    context.Add(cart1);
                    context.Add(cart2);
                    context.Add(cart3);

                    context.Add(cartSkucountScenario1_1);
                    context.Add(cartSkucountScenario1_2);
                    context.Add(cartSkucountScenario1_3);


                    context.Add(cartSkucountScenario2_1);
                    context.Add(cartSkucountScenario2_2);
                    context.Add(cartSkucountScenario2_3);


                    context.Add(cartSkucountScenario3_1);
                    context.Add(cartSkucountScenario3_2);
                    context.Add(cartSkucountScenario3_3);
                    context.Add(cartSkucountScenario3_4);


                    context.Add(cartSkucountScenario4_1);
                    context.Add(cartSkucountScenario4_2);
                    context.Add(cartSkucountScenario4_3);
                    context.Add(cartSkucountScenario4_4);

                    context.Add(product1);
                    context.Add(product2);
                    context.Add(product3);
                    context.Add(product4);

                    context.Add(promotionSkucount1);
                    context.Add(promotionSkucount2);
                    context.Add(promotionSkucount3);
                    context.Add(promotionSkucount4);
                    context.Add(promotionSkucount5);
                    context.Add(promotionSkucount6);

                    context.Add(promotion1);
                    context.Add(promotion2);
                    context.Add(promotion3);
                    context.Add(promotion4);

                    context.SaveChanges();
                }
            }




        }
    }
}
