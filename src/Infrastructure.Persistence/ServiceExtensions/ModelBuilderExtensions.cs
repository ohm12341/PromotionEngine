﻿using Infrastructure.Persistence.Contexts;
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
                        SKU = 1,
                        PromotionId = 1
                    };
                    var promotionSkucount2 = new PromotionSkuCount()
                    {
                        Id = 2,
                        Count = 2,
                        SKU = 2,
                        PromotionId = 2
                    };

                    var promotionSkucount3 = new PromotionSkuCount()
                    {
                        Id = 3,
                        Count = 1,
                        SKU = 3,
                        PromotionId = 3
                    };


                    var promotionSkucount4 = new PromotionSkuCount()
                    {
                        Id = 4,
                        Count = 1,
                        SKU = 4,
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

                    context.Add(cart);
                    context.Add(product1);
                    context.Add(product2);
                    context.Add(product3);
                    context.Add(product4);

                    context.Add(promotionSkucount1);
                    context.Add(promotionSkucount2);
                    context.Add(promotionSkucount3);
                    context.Add(promotionSkucount4);

                    context.Add(promotion1);
                    context.Add(promotion2);
                    context.Add(promotion3);

                    context.SaveChanges();
                }
            }




        }
    }
}
