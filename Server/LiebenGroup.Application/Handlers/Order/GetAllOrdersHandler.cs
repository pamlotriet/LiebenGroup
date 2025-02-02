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
            IEnumerable<LiebenGroupServer.DataAccess.Models.Order> orders = await _orderRepository.GetAllAsync();

            if (orders == null)
                return new List<OrderDto>();

            return orders.Adapt<IEnumerable<OrderDto>>();
        }
    }
}
