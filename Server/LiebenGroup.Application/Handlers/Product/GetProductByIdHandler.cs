﻿
using LiebenGroupServer.Application.Dto;
using LiebenGroupServer.Application.Queries.Product;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Mapster;
using MediatR;

namespace LiebenGroupServer.Application.Handlers.Product
{
   

    public class GetProductByIdHandler: IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            LiebenGroupServer.DataAccess.Models.Product product = await _productRepository.GetByIdAsync(request.Id);
          return product.Adapt<ProductDto>();
        }
    }
}
