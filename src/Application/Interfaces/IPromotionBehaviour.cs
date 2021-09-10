using System.Threading.Tasks;

namespace PE.Application.Interfaces
{
    public interface IPromotionBehaviour
    {
        public Task<decimal> GetCartTotalAfterApplyingPromotions(int cartId);
    }
}
