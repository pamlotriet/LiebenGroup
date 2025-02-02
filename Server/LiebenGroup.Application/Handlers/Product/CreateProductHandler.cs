using LiebenGroupServer.Application.Commands.Product;
using LiebenGroupServer.Application.Dto;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using LiebenGroupServer.DataAccess.Models;
using Mapster;
using MapsterMapper;
using MediatR;
namespace LiebenGroupServer.Application.Handlers.Product
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            ProductDto product = new(request.Name, request.Price);
            await _productRepository.AddAsync(product.Adapt<LiebenGroupServer.DataAccess.Models.Product> ());

            return product;
        }
    }

}
