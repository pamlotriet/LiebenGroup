using LiebenGroupServer.Application.Commands.Product;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using MediatR;

namespace LiebenGroupServer.Application.Handlers.Product
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetByIdAsync(request.Id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found."); // ✅ 404 Not Found
            try
            {
                await _productRepository.DeleteAsync(request.Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
