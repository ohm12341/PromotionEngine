
using PE.Domain.BoundedContext.Product.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PE.Application.Interfaces
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        public Task<Product> GetProductWithAllRelatedProperties(int Id);

        public Task<List<Product>> GetProductAllWithAllRelatedProperties();
    }
}
