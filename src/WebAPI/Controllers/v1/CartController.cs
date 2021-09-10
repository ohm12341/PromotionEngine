using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using PE.Application.Features.Cart.Queries;
using PE.Application.Interfaces;
using PE.Domain.Cart.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [ApiVersion("1.0")]
    public class CartController : BaseApiController
    {

        [HttpGet("{Id}/Promotions")]
        public async Task<IActionResult> GetCartWithPromotion(int Id)
        {
            return Ok(await Mediator.Send(new GetCartTotalAfterPromotionsQuery() {  CartId=Id }));
          
        }


    }
}
