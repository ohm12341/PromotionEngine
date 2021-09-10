using PE.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PE.Application.Interfaces
{
    public interface ICartRepositoryAsync
    {
        public Task<IEnumerable<PE.Domain.Cart.Entities.Cart>> GetCartAllWithAllRelatedProperties();
    }
}
