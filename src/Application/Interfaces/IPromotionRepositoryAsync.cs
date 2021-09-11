using PE.Domain.Promotions.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PE.Application.Interfaces
{
    public interface IPromotionRepositoryAsync  : IGenericRepositoryAsync<Promotion>
    {
        public Task<PE.Domain.Promotions.Entities.Promotion> GetPromotionsAllWithAllRelatedProperties(int Id);
    }
}
