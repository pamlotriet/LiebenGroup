using System.ComponentModel.DataAnnotations;

namespace LiebenGroupServer.Application.Dto
{
    public class AddProductDto
    {
        [Required] 
        [MinLength(2, ErrorMessage = "Product name must have at least 2 characters.")]
        public string Name { get; set; }
        [Required] 
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
    }
}
