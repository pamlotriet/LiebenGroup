using LiebenGroupServer.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.Application.Queries.Product
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>> 
    {
    }

}
