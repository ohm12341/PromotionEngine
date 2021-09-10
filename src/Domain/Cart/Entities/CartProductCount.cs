using PE.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PE.Domain.Cart.Entities
{
   public class CartProductCount : BaseEntity
    {
        public int Count { get; set; }
        public int productId { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
