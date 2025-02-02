using LiebenGroupServer.Application.Commands.Product;
using LiebenGroupServer.Application.Dto;
using LiebenGroupServer.Application.Queries.Product;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiebenGroupServer.Api.Controllers
{

    [Route("product")]
    [ApiController]
    public class ProductController : Controller
    {
        public readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto dto)
        {
            var command = new CreateProductCommand(dto.Name, dto.Price);
            var createdProduct = await _mediator.Send(command);
            return Ok(createdProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var deletedid = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(deletedid);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto dto)
        {
            var command = new UpdateProductCommand(dto.Name, dto.Price);
            var createdProduct = await _mediator.Send(command);
            return Ok(createdProduct);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }
    }
}
