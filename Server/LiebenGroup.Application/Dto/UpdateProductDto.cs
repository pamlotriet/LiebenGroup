using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.Application.Dto
{
    public class UpdateProductDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Product name must have at least 2 characters.")]
        public string Name { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
    }
}
