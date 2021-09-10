using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using PE.Application.Interfaces;
using PE.Domain.Cart.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepositoryAsync cartRepositoryAsync;

        public CartController(ICartRepositoryAsync cartRepositoryAsync)
        {
            this.cartRepositoryAsync = cartRepositoryAsync;
        }

        // GET: CartController
        public async Task<IEnumerable<Cart>> Cart()
        {
            var cart = await cartRepositoryAsync.GetCartAllWithAllRelatedProperties();

            return cart.ToList();
        }


    }
}
