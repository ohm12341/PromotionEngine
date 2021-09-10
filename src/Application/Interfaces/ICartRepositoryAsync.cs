using PE.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PE.Application.Interfaces
{
    public interface ICartRepositoryAsync
    {
        public Task<PE.Domain.Cart.Entities.Cart> GetCartAllWithAllRelatedProperties(int Id);
    }
}
