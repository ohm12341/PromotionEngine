using PE.Domain.BoundedContext.Product.Entities;
using PE.Domain.Common;
using PE.Domain.Promotions.Entities;
using PE.Domain.Promotions.Enums;
using System;
using System.Collections.Generic;

namespace PE.Domain.Promotions.Entities
{
    public class Promotion : BaseEntityWithAudit
    {

        public string Name { get; set; }


        public int PromotionTypeId { get; set; }


        public bool UsePercentage { get; set; }


        public int ProductId { get; set; }

        public decimal PromotionAmount { get; set; }

        public DateTime? StartDate { get; set; }


        public DateTime? EndDate { get; set; }


        public bool IsCumulative { get; set; }


        public int MinimumPromotionedQuantity { get; set; }


        public virtual Product Product { get; set; }

        public virtual ICollection<PromotionSkuCount> PromotionSkuCounts { get; set; }

        public PromotionType PromotionType
        {
            get => (PromotionType)PromotionTypeId;
            set => PromotionTypeId = (int)value;
        }
    }
}
