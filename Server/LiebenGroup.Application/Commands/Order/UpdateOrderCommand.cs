using LiebenGroupServer.Application.Dto;
using MediatR;

namespace LiebenGroupServer.Application.Commands.Order
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderLineItemDto> Items { get; set; }

        public UpdateOrderCommand(DateTime orderDate, decimal totalAmount, List<OrderLineItemDto> items, Guid id)
        {
            Id = id;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            Items = items;
        }
    }
}
