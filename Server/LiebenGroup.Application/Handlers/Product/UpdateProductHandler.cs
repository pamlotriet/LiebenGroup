using LiebenGroupServer.Application.Commands.Product;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
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
                throw new ValidationException("Product name cannot be empty.");

            if (request.Price <= 0)
                throw new ValidationException("Price must be greater than zero."); 

            var existingProduct = await _productRepository.GetByIdAsync(request.Id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");

            existingProduct.Name = request.Name;
            existingProduct.Price = request.Price;

            try
            {
                await _productRepository.UpdateAsync(existingProduct);
            }
            catch
            {
                throw;
            }
            
        }
    }
}
