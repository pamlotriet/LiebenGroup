using LiebenGroupServer.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.Application.Queries.Order
{
    public class GetAllOrdersQuery: IRequest<IEnumerable<OrderDto>> 
    {
    }
}
