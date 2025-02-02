using LiebenGroupServer.Application.Dto;
using LiebenGroupServer.Application.Queries.Order;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Mapster;
using MediatR;

namespace LiebenGroupServer.Application.Handlers.Order
{

    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            LiebenGroupServer.DataAccess.Models.Order? order = await _orderRepository.GetByIdAsync(request.Id);
            return order.Adapt<OrderDto>();
        }
    }
}
