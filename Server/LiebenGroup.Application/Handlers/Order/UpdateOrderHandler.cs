using LiebenGroupServer.Application.Commands.Order;
using LiebenGroupServer.DataAccess.Models;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Mapster;
using MediatR;

namespace LiebenGroupServer.Application.Handlers.Order
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

          
                var existingOrder = await _orderRepository.GetByIdAsync(request.Id);
                if (existingOrder == null)
                    throw new KeyNotFoundException($"Order with ID {request.Id} not found.");

                existingOrder.OrderDate = request.OrderDate;
               
                List<OrderLineItem> updatedLineItems = request.Items.Adapt<List<OrderLineItem>>();


                await _orderRepository.UpdateAsync(existingOrder, updatedLineItems);
       
        }
    }
}
