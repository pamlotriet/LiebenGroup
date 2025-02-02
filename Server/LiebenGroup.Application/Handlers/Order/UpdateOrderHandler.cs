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

        public Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new { request.OrderDate, request.TotalAmount }.Adapt<LiebenGroupServer.DataAccess.Models.Order>();
            return _orderRepository.UpdateAsync(order, request.Items.Adapt<List<OrderLineItem>>());
        }
    }
}
