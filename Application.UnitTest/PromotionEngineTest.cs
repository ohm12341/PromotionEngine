using PE.Application.Features.Promotion.Engine;
using PE.Domain.Cart.Entities;
using PE.Domain.Promotions.Engine;
using PE.Domain.Promotions.Entities;
using PE.Domain.Promotions.Enums;
using System.Collections.Generic;
using Xunit;

namespace Application.UnitTest
{
    public class PromotionEngineTest
    {
        [Fact]
        public void get_total_amount_for_product_withOut_promotions()
        {
            IPromotionEngine promotionEngine = new PromotionEngine();

            var totalPrice = promotionEngine.GetAssignedToSingleSkusAmount(1, 3, 130, 50);

            Assert.Equal(50, totalPrice);

        }

        [Fact]
        public void get_total_amount_for_product_withOut_promotions_when_promotioncount_is_zero_returns_zero()
        {
            IPromotionEngine promotionEngine = new PromotionEngine();

            var totalPrice = promotionEngine.GetAssignedToSingleSkusAmount(1, 0, 130, 50);

            Assert.Equal(0, totalPrice);

        }

        [Fact]
        public void get_total_amount_for_product_withOut_promotions_when_cartcount_is_zero_returns_zero()
        {
            IPromotionEngine promotionEngine = new PromotionEngine();

            var totalPrice = promotionEngine.GetAssignedToSingleSkusAmount(0, 45, 130, 50);

            Assert.Equal(0, totalPrice);

        }

        [Fact]
        public void get_total_amount_for_product_with_promotions_applys_promotion_and_return_new_total()
        {
            IPromotionEngine promotionEngine = new PromotionEngine();

            var totalPrice = promotionEngine.GetAssignedToSingleSkusAmount(2, 2, 130, 50);

            Assert.Equal(130, totalPrice);

        }

        [Fact]
        public void get_total_amount_for_product_with_promotions_and_without_promotion_applys_promotion_and_return_new_total()
        {
            IPromotionEngine promotionEngine = new PromotionEngine();

            var totalPrice = promotionEngine.GetAssignedToSingleSkusAmount(3, 2, 130, 50);

            Assert.Equal(180, totalPrice);

        }

        [Fact]
        public void get_total_amount_for_product_with__multiplepromotions_applys_promotion_and_return_new_total()
        {
            IPromotionEngine promotionEngine = new PromotionEngine();

            var totalPrice = promotionEngine.GetAssignedToSingleSkusAmount(4, 2, 130, 50);

            Assert.Equal(260, totalPrice);

        }



        [Fact]
        public void can_apply_multiplesku_promotion_with_valid_product_and_promoton_return_true()
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
                PromotionSkuCounts = new List<PromotionSkuCount>() { promotionSkucount1, promotionSkucount2 }

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
            var cartSkucount = new List<CartProductCount>() { cartSkucountScenario2_1,    cartSkucountScenario2_2
            };

            IPromotionEngine promotionEngine = new PromotionEngine();

            var canapplypromotions = promotionEngine.CanApplyMultipleSkuPromotion(promotion1, cartSkucount);

            Assert.True(canapplypromotions);

        }

        [Fact]
        public void can_apply_multiplesku_promotion_with_invalid_product_and_promoton_return_false()
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
                Count = 1,
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
                PromotionSkuCounts = new List<PromotionSkuCount>() { promotionSkucount1, promotionSkucount2 }

            };
            var cartSkucountScenario2_1 = new CartProductCount()
            {
                Id = 4,
                Count = 2,
                productId = 1,
                CartId = 2
            };
            var cartSkucountScenario2_2 = new CartProductCount()
            {
                Id = 5,
                Count = 2,
                productId = 2,
                CartId = 2
            };
            var cartSkucount = new List<CartProductCount>() { cartSkucountScenario2_1,    cartSkucountScenario2_2
            };

            IPromotionEngine promotionEngine = new PromotionEngine();

            var canapplypromotions = promotionEngine.CanApplyMultipleSkuPromotion(promotion1, cartSkucount);

            Assert.False(canapplypromotions);

        }


        [Fact]
        public void can_apply_multiplesku_promotion_with_empty_cart_return_false()
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
                Count = 1,
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
                PromotionSkuCounts = new List<PromotionSkuCount>() { promotionSkucount1, promotionSkucount2 }

            };
            var cartSkucount = new List<CartProductCount>();

            IPromotionEngine promotionEngine = new PromotionEngine();

            var canapplypromotions = promotionEngine.CanApplyMultipleSkuPromotion(promotion1, cartSkucount);

            Assert.False(canapplypromotions);

        }
    }
}
