using System.ComponentModel.DataAnnotations;

namespace LiebenGroupServer.Application.Dto
{
    public class OrderDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required] 
        [DataType(DataType.DateTime)]
        [Range(typeof(DateTime), "1/1/2000", "12/31/2099", ErrorMessage = "OrderDate must be a valid date.")]
        public DateTime OrderDate { get; set; }
        [Required] 
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalAmount must be greater than zero.")]
        public decimal TotalAmount { get; set; }
        [Required] 
        [MinLength(1, ErrorMessage = "An order must contain at least one item.")]
        public List<OrderLineItemDto> Items { get; set; } = new();
    }

}
