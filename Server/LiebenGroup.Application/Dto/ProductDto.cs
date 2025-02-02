using System.ComponentModel.DataAnnotations;

namespace LiebenGroupServer.Application.Dto
{
    public class ProductDto
    {
        public ProductDto(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        //for mapster to work
        public ProductDto() { }


        public Guid Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must have at least 2 characters.")]
        public string Name { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
    }

}
