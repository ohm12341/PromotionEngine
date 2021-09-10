using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PE.Application.Interfaces
{
    public interface IPromotionRepositoryAsync
    {
        public Task<PE.Domain.Promotions.Entities.Promotion> GetPromotionsAllWithAllRelatedProperties(int Id);
    }
}
