using System.Threading.Tasks;

namespace PE.Application.Interfaces
{
    public interface ICartBehaviour
    {
        public Task<decimal> GetCartTotalAfterApplyingPromotions(int cartId);
    }
}
