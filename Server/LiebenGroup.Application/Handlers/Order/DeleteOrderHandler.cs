using LiebenGroupServer.Application.Commands.Order;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using MediatR;

namespace LiebenGroupServer.Application.Handlers.Order
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand>
    {

        private readonly IOrderRepository _orderRepository;

        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {

           
                LiebenGroupServer.DataAccess.Models.Order existingOrder = await _orderRepository.GetByIdAsync(request.Id);
                if (existingOrder == null)
                    throw new KeyNotFoundException($"Order with ID {request.Id} not found."); // ✅ 404 Not Found

                await _orderRepository.DeleteAsync(request.Id);
            
      
      
        }

    }
}
