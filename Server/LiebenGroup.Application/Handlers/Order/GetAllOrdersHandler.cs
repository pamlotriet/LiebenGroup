using LiebenGroupServer.Application.Dto;
using LiebenGroupServer.Application.Queries.Order;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Mapster;
using MediatR;

namespace LiebenGroupServer.Application.Handlers.Order
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            if (orders == null || !orders.Any())
                return new List<OrderDto>();

            return orders.Select(order => new OrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Items = order.Items.Adapt<List<OrderLineItemDto>>(),
                TotalAmount = order.Items.Sum(i => i.TotalPrice) 
            });
        }
    }
}
