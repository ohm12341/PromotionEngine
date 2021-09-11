using PE.Domain.Common;

namespace PE.Domain.Promotions.Entities
{
    public class PromotionSkuCount : BaseEntity
    {
        public int Count { get; set; }
        public int productId { get; set; }

        public int PromotionId { get; set; }

        public virtual Promotions.Entities.Promotion Promotion { get; set; }
    }
}
