using LiebenGroupServer.Application.Dto;
using MediatR;
namespace LiebenGroupServer.Application.Commands.Order
{
    public class CreateOrderCommand: IRequest
    {

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderLineItemDto> Items { get; set; }

        public CreateOrderCommand(DateTime orderDate, decimal totalAmount, List<OrderLineItemDto> items)
        {
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            Items = items;
        }
    }
}
