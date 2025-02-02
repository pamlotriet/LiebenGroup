using LiebenGroupServer.Application.Commands.Order;
using LiebenGroupServer.DataAccess.Models;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LiebenGroupServer.Application.Handlers.Order
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (request.Items == null || request.Items.Count == 0)
                throw new ValidationException("An order must contain at least one item.");

            if (request.TotalAmount <= 0)
                throw new ValidationException("TotalAmount must be greater than zero.");

            if (request.OrderDate > DateTime.UtcNow)
                throw new ValidationException("Order date cannot be in the future.");
            try
            {
                LiebenGroupServer.DataAccess.Models.Order order = new { request.OrderDate, request.TotalAmount }.Adapt<LiebenGroupServer.DataAccess.Models.Order>();
                await _orderRepository.AddAsync(order, request.Items.Adapt<List<OrderLineItem>>());
            }
            catch
            {
                throw;
            }
        }
    }
}
