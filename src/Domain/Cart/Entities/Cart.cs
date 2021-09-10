using PE.Domain.BoundedContext.Product.Entities;
using PE.Domain.Common;
using System.Collections.Generic;

namespace PE.Domain.Cart.Entities
{
    public class Cart : BaseEntityWithAudit
    {
        public List<Product> Products { get; set; }

    }
}
