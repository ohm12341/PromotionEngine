using PE.Application.Interfaces;
using PE.Domain.Promotions.Engine;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Application.Behaviour
{
    public class CartBehaviour : ICartBehaviour
    {

        private readonly ICartRepositoryAsync cartRepository;
        private readonly IProductRepositoryAsync productRepositoryAsync;
        private readonly IPromotionRepositoryAsync promotionRepositoryAsync;
        private readonly IPromotionEngine promotionEngine;

        public CartBehaviour(ICartRepositoryAsync cartRepository,
            IProductRepositoryAsync productRepositoryAsync,
            IPromotionRepositoryAsync promotionRepositoryAsync,
            IPromotionEngine promotionEngine)
        {
            this.cartRepository = cartRepository;
            this.productRepositoryAsync = productRepositoryAsync;
            this.promotionRepositoryAsync = promotionRepositoryAsync;
            this.promotionEngine = promotionEngine;
        }

        public async Task<decimal> GetCartTotalAfterApplyingPromotions(int cartId)
        {
            try
            {
                bool promotionapplied = false;
                decimal totalPrice = 0;

                var cart = await cartRepository.GetByIdAsync(cartId);
                if (cart == null)
                    return 0;

                foreach (var cartProductCount in cart.CartProductCount)
                {
                    var product = await productRepositoryAsync.GetProductWithAllRelatedProperties(cartProductCount.productId);

                    foreach (var promotionSkuCount in product.PromotionSkuCounts)
                    {
                        var promotion = await promotionRepositoryAsync.GetPromotionsAllWithAllRelatedProperties(promotionSkuCount.PromotionId);

                        if (promotion.PromotionType == Domain.Promotions.Enums.PromotionType.AssignedToSingleSkus)
                        {
                            totalPrice += promotionEngine.GetAssignedToSingleSkusAmount(cartProductCount.Count, promotion.MinimumPromotionedQuantity, promotion.PromotionAmount, product.Price);
                            if (promotion.UsePercentage)
                            {
                                totalPrice += (decimal)promotion.PromotionPercentage / 100 * product.Price;
                            }
                        }
                        else if (promotion.PromotionType == Domain.Promotions.Enums.PromotionType.AssignedToMultipleSkus)
                        {

                            bool canapplyPromotion = promotionEngine.CanApplyMultipleSkuPromotion(promotion, cart.CartProductCount.ToList());

                            if (canapplyPromotion && !promotionapplied)
                            {
                                totalPrice += promotion.PromotionAmount;
                                promotionapplied = true;

                            }
                            if (promotionapplied)
                            {
                                var promotionSkucountForProduct = promotion.PromotionSkuCounts.FirstOrDefault(x => x.productId == product.Id);
                                totalPrice += (cartProductCount.Count - promotionSkucountForProduct.Count) >= 0 ? (cartProductCount.Count - promotionSkucountForProduct.Count) * product.Price : 0;
                                break;
                            }
                            else
                            {
                                totalPrice += product.Price;
                                break;
                            }

                        }


                    }
                }
                return totalPrice;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
