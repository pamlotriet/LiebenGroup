using System.ComponentModel.DataAnnotations;

namespace LiebenGroupServer.Application.Dto
{
    public class CreateUpdateOrderDto
    {
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
