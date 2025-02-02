using LiebenGroupServer.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.Application.Commands.Order
{
    public class UpdateOrderCommand : IRequest
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderLineItemDto> Items { get; set; }

        public UpdateOrderCommand(DateTime orderDate, decimal totalAmount, List<OrderLineItemDto> items)
        {
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            Items = items;
        }
    }
}
