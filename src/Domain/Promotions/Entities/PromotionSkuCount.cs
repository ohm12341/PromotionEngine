﻿using PE.Domain.Common;

namespace PE.Domain.Promotions.Entities
{
    public class PromotionSkuCount : BaseEntity
    {
        public int Count { get; set; }
        public int SKU { get; set; }

        public int PromotionId { get; set; }

        public Promotions.Entities.Promotion Promotion { get; set; }
    }
}