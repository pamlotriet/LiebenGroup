using LiebenGroupServer.Application.Commands.Product;
using LiebenGroupServer.Application.Dto;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations;
namespace LiebenGroupServer.Application.Handlers.Product
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("Product name cannot be empty.");

            if (request.Price <= 0)
                throw new ValidationException("Price must be greater than zero.");

            try
            {
                ProductDto product = new(request.Name, request.Price);
                await _productRepository.AddAsync(product.Adapt<LiebenGroupServer.DataAccess.Models.Product>());
            }
            catch 
            {
                throw;
            }
        }
    }

}
