using PE.Domain.Cart.Entities;
using System.Threading.Tasks;

namespace PE.Application.Interfaces
{
    public interface ICartRepositoryAsync : IGenericRepositoryAsync<Cart>
    {
        public Task<PE.Domain.Cart.Entities.Cart> GetCartAllWithAllRelatedProperties(int Id);
    }
}
