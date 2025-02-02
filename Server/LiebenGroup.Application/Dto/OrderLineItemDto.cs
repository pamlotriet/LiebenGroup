using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.Application.Dto
{
    public class OrderLineItemDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required] 
        [MinLength(2, ErrorMessage = "ProductName must have at least 2 characters.")]
        public string ProductName { get; set; } = string.Empty;
        [Required] 
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        [Required] 
        [Range(0.01, double.MaxValue, ErrorMessage = "UnitPrice must be greater than zero.")]
        public decimal UnitPrice { get; set; }
        public decimal GetTotalPrice() => Quantity * UnitPrice;
    }

}
