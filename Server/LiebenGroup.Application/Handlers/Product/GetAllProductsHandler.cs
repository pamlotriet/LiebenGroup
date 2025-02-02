using LiebenGroupServer.Application.Dto;
using LiebenGroupServer.Application.Queries.Product;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Mapster;
using MediatR;

namespace LiebenGroupServer.Application.Handlers.Product
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<LiebenGroupServer.DataAccess.Models.Product> products = await _productRepository.GetAllAsync();

            if (products == null)
                return new List<ProductDto>();

            return products.Adapt<List<ProductDto>>();
        }
    }
}
