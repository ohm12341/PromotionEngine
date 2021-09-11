using PE.Domain.Cart.Entities;
using PE.Domain.Promotions.Entities;
using System.Collections.Generic;

namespace PE.Domain.Promotions.Engine
{
    public interface IPromotionEngine
    {
        public decimal GetAssignedToSingleSkusAmount(
            int cartproductCount,
            int minimumPromotionedQuantity,
           decimal promotionAmount,
           decimal productPrice);

        public bool CanApplyMultipleSkuPromotion(Promotion promotion, List<CartProductCount> cartProductCounts);
    }
}
