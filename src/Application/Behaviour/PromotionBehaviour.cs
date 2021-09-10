using PE.Application.Interfaces;
using PE.Domain.Promotions.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Application.Behaviour
{
    public class PromotionBehaviour : IPromotionBehaviour
    {

        private readonly ICartRepositoryAsync cartRepository;
        private readonly IProductRepositoryAsync productRepositoryAsync;
        private readonly IPromotionRepositoryAsync promotionRepositoryAsync;
        private readonly IGenericRepositoryAsync<PromotionSkuCount> promotionSkuCountRepositoryAsync;
        public PromotionBehaviour(ICartRepositoryAsync cartRepository,
            IProductRepositoryAsync productRepositoryAsync,
            IPromotionRepositoryAsync promotionRepositoryAsync,
            IGenericRepositoryAsync<PromotionSkuCount> promotionSkuCountRepositoryAsync)
        {
            this.cartRepository = cartRepository;
            this.productRepositoryAsync = productRepositoryAsync;
            this.promotionRepositoryAsync = promotionRepositoryAsync;
            this.promotionSkuCountRepositoryAsync = promotionSkuCountRepositoryAsync;
        }

        public async Task<decimal> GetCartTotalAfterApplyingPromotions(int cartId)
        {
            try
            {
                bool promotionapplied=false;
                decimal totalPrice = 0;

                var cart = await cartRepository.GetCartAllWithAllRelatedProperties(cartId);

                foreach (var cartProductCount in cart.CartProductCount)
                {
                    var product = await productRepositoryAsync.GetProductAllWithAllRelatedProperties(cartProductCount.productId);

                    foreach (var promotionSkuCount in product.PromotionSkuCounts)
                    {
                        var promotion = await promotionRepositoryAsync.GetPromotionsAllWithAllRelatedProperties(promotionSkuCount.PromotionId);

                        if (promotion.PromotionType == Domain.Promotions.Enums.PromotionType.AssignedToSingleSkus)
                        {
                            int numberofPromotedProduct;
                            int numberofNonPromotedProduct;

                            numberofPromotedProduct = Math.DivRem(cartProductCount.Count, promotion.MinimumPromotionedQuantity, out numberofNonPromotedProduct);

                            totalPrice += numberofPromotedProduct * promotion.PromotionAmount;
                            totalPrice += numberofNonPromotedProduct * product.Price;

                        }
                        else if (promotion.PromotionType == Domain.Promotions.Enums.PromotionType.AssignedToMultipleSkus)
                        {
                            int numberofPromotedProduct;
                            int numberofNonPromotedProduct=1;
                            bool canapplyPromotion = false;
                           
                            foreach (var promotionproduct in promotion.PromotionSkuCounts)
                            {
                                if (cart.CartProductCount.Any(x => x.productId == promotionproduct.productId) && cart.CartProductCount.Any(x=>x.Count==promotionproduct.Count))
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

                            if (canapplyPromotion&&!promotionapplied)
                            {
                                totalPrice += promotion.PromotionAmount;
                                promotionapplied = true;
                                break;
                            }
                            totalPrice += numberofNonPromotedProduct * product.Price;

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
