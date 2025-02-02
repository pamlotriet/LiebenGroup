using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.Application.Dto
{
    public class UpdateOrderDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalAmount must be greater than zero.")]
        public decimal TotalAmount { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "An order must contain at least one item.")]
        public List<OrderLineItemDto> Items { get; set; } = new();
    }
}
