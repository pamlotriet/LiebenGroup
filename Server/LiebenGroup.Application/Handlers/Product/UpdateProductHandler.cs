using LiebenGroupServer.Application.Commands.Product;
using LiebenGroupServer.Application.Dto;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LiebenGroupServer.Application.Handlers.Product
{
    public class UpdateProductHandler :  IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("Product name cannot be empty."); // ✅ 400 Bad Request

            if (request.Price <= 0)
                throw new ValidationException("Price must be greater than zero."); // ✅ 400 Bad Request

            // ✅ Fetch existing product
            var existingProduct = await _productRepository.GetByIdAsync(request.Id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found."); // ✅ 404 Not Found

            // ✅ Update product properties
            existingProduct.Name = request.Name;
            existingProduct.Price = request.Price;

            await _productRepository.UpdateAsync(existingProduct);
        }
    }
}
