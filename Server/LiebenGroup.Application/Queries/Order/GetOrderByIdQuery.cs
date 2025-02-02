using LiebenGroupServer.Application.Dto;
using MediatR;

namespace LiebenGroupServer.Application.Queries.Order
{
    public class GetOrderByIdQuery: IRequest<OrderDto>
    {
        public Guid Id { get; }

        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
