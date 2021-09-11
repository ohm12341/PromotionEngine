using PE.Domain.Cart.Entities;
using PE.Domain.Promotions.Engine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PE.Application.Features.Promotion.Engine
{
    public class PromotionEngine : IPromotionEngine
    {
     

        public bool CanApplyMultipleSkuPromotion(Domain.Promotions.Entities.Promotion promotion,
            List<CartProductCount> cartProductCounts )
        {
            try
            {

                if (cartProductCounts.Count == 0)
                {
                    return false;
                }
               
                bool canapplyPromotion = false;

                foreach (var promotionproduct in promotion.PromotionSkuCounts)
                {
                    if (cartProductCounts.Any(x => x.productId == promotionproduct.productId) && cartProductCounts.Any(x => x.Count >= promotionproduct.Count))
                    {
                        canapplyPromotion = true;
                        continue;
                    }
                    else
                    {
                        canapplyPromotion = false;
                        break;
                    }
                }

                return canapplyPromotion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public decimal GetAssignedToSingleSkusAmount(int cartproductCount, int minimumPromotionedQuantity, decimal promotionAmount, decimal productPrice)
        {
            try
            {
                if(cartproductCount==0 || minimumPromotionedQuantity ==0 )
                {
                    return 0;
                }

                decimal totalPrice = 0;

                int numberofPromotedProduct;
                int numberofNonPromotedProduct;

                numberofPromotedProduct = Math.DivRem(cartproductCount, minimumPromotionedQuantity, out numberofNonPromotedProduct);

                totalPrice += numberofPromotedProduct * promotionAmount;
                totalPrice += numberofNonPromotedProduct * productPrice;
                return totalPrice;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
