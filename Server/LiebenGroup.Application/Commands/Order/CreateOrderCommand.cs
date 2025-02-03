using LiebenGroupServer.Application.Dto;
using MediatR;
namespace LiebenGroupServer.Application.Commands.Order
{
    public class CreateOrderCommand: IRequest
    {

        public DateTime OrderDate { get; set; }
        public List<OrderLineItemDto> Items { get; set; }

        public CreateOrderCommand(DateTime orderDate, List<OrderLineItemDto> items)
        {
            OrderDate = orderDate;
            Items = items;
        }
    }
}
