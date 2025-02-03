using System.ComponentModel.DataAnnotations;

namespace LiebenGroupServer.Application.Dto
{
    public class CreateUpdateOrderDto
    {
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "An order must contain at least one item.")]
        public List<OrderLineItemDto> Items { get; set; } = new();
       
    }
}
