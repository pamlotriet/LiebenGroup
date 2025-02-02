using LiebenGroupServer.Application.Commands.Order;
using LiebenGroupServer.DataAccess.Models;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Mapster;
using MediatR;

namespace LiebenGroupServer.Application.Handlers.Order
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new {request.OrderDate,request.TotalAmount}.Adapt<LiebenGroupServer.DataAccess.Models.Order>();
            return _orderRepository.AddAsync(order, request.Items.Adapt<List<OrderLineItem>>());
        }
    }
}
