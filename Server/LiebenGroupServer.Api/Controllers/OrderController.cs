using LiebenGroupServer.Application.Commands.Order;
using LiebenGroupServer.Application.Dto;
using LiebenGroupServer.Application.Queries.Order;
using LiebenGroupServer.Application.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiebenGroupServer.Api.Controllers
{

    [Route("order")]
    [ApiController]
    public class OrderController : Controller
    {
        public readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateUpdateOrderDto dto)
        {
            var command = new CreateOrderCommand(dto.OrderDate,dto.Items);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto dto)
        {
            var command = new UpdateOrderCommand(dto.OrderDate, dto.TotalAmount, dto.Items, dto.Id);
            await _mediator.Send(command);
            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            return Ok(await _mediator.Send(new GetOrderByIdQuery(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _mediator.Send(new GetAllOrdersQuery()));
        }
    }
}
