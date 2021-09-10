using PE.Application.Interfaces;
using PE.Domain.BoundedContext.Product.Entities;
using PE.Domain.Promotions.Entities;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace PE.Application.Behaviour
{
    public class PromotionBehaviour : IPromotionBehaviour
    {

        private readonly ICartRepositoryAsync cartRepository;
        private readonly IGenericRepositoryAsync<Product> productRepositoryAsync;
        private readonly IGenericRepositoryAsync<Promotion> promotionRepositoryAsync;
        private readonly IGenericRepositoryAsync<PromotionSkuCount> promotionSkuCountRepositoryAsync;
        public PromotionBehaviour(ICartRepositoryAsync cartRepository,
            IGenericRepositoryAsync<Product> productRepositoryAsync,
            IGenericRepositoryAsync<Promotion> promotionRepositoryAsync,
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
                decimal totalPrice=0;

                var cart = await cartRepository.GetCartAllWithAllRelatedProperties(cartId);
                
                foreach (var product in cart.Products)
                {
                    foreach (var promotionSkuCount in product.PromotionSkuCounts)
                    {
                        var promotion = await promotionRepositoryAsync.GetByIdAsync(promotionSkuCount.PromotionId);

                        if (promotion.PromotionType == Domain.Promotions.Enums.PromotionType.AssignedToSingleSkus)
                        {
                            int numberofPromotedProduct;
                            int numberofNonPromotedProduct;
                           
                            numberofPromotedProduct= Math.DivRem(cart.CartProductCount.FirstOrDefault(x => x.productId == product.Id).Count, promotion.MinimumPromotionedQuantity, out numberofNonPromotedProduct);

                            totalPrice += numberofPromotedProduct * promotion.PromotionAmount;
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
