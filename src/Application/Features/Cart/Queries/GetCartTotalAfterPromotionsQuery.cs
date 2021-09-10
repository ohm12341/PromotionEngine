using AutoMapper;
using MediatR;
using PE.Application.Interfaces;
using PE.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PE.Application.Features.Cart.Queries
{
  
    public class GetCartTotalAfterPromotionsQuery : IRequest<Response<decimal>>
    {
        public int CartId { get; set; }

    }
    public class GetCartWithPromotionsQueryHandler : IRequestHandler<GetCartTotalAfterPromotionsQuery, Response<decimal>>
    {
        private readonly ICartRepositoryAsync _productRepository;
       
        public GetCartWithPromotionsQueryHandler(ICartRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
           
        }

        public async Task<Response<decimal>> Handle(GetCartTotalAfterPromotionsQuery request, CancellationToken cancellationToken)
        {
           // var validFilter = _mapper.Map<GetAllProductsParameter>(request);
            var product = await _productRepository.GetCartAllWithAllRelatedProperties(request.CartId);
            return new Response<decimal>(request.CartId);
        }
    }
}
