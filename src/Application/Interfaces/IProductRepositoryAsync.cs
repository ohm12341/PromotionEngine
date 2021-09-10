
using PE.Domain.BoundedContext.Product.Entities;
using System.Threading.Tasks;

namespace PE.Application.Interfaces
{
    public interface IProductRepositoryAsync
    {
        public Task<Product> GetProductAllWithAllRelatedProperties(int Id);
    }
}
