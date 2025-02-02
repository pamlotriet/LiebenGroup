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
             await _orderRepository.DeleteAsync(request.Id);
        }
    }
}
