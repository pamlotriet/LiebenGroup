using LiebenGroupServer.Application.Dto;
using MediatR;

namespace LiebenGroupServer.Application.Commands.Order
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderLineItemDto> Items { get; set; }

        public UpdateOrderCommand(DateTime orderDate, List<OrderLineItemDto> items, Guid id)
        {
            Id = id;
            OrderDate = orderDate;
            Items = items;
        }
    }
}
