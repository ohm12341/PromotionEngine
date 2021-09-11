using PE.Domain.Common;
using PE.Domain.Promotions.Entities;
using System.Collections.Generic;

namespace PE.Domain.BoundedContext.Product.Entities
{
    public class Product : BaseEntityWithAudit
    {
        public string SKU { get; set; }

        public decimal Price { get; set; }

        public int CartID { get; set; }

        public virtual Cart.Entities.Cart Cart { get; set; }

        public virtual ICollection<Promotion> Promotions { get; set; }

        public  virtual ICollection<PromotionSkuCount> PromotionSkuCounts { get; set; }
    }
}
