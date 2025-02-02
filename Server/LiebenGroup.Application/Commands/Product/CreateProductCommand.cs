using LiebenGroupServer.Application.Dto;
using MediatR;

namespace LiebenGroupServer.Application.Commands.Product
{
    public class CreateProductCommand : IRequest
    {
        public string Name { get; }
        public decimal Price { get; }

        public CreateProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

}
