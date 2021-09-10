using MediatR;
using PE.Application.Interfaces;
using PE.Application.Wrappers;
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
        private readonly IPromotionBehaviour promotionBehaviour;

        public GetCartWithPromotionsQueryHandler(IPromotionBehaviour promotionBehaviour)
        {
            this.promotionBehaviour = promotionBehaviour;
        }

        public async Task<Response<decimal>> Handle(GetCartTotalAfterPromotionsQuery request, CancellationToken cancellationToken)
        {
            // var validFilter = _mapper.Map<GetAllProductsParameter>(request);

            var totalprice = await promotionBehaviour.GetCartTotalAfterApplyingPromotions(request.CartId);


            return new Response<decimal>(decimal.Parse(totalprice.ToString()));
        }
    }
}
