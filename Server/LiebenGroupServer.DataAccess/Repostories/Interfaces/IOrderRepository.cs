using LiebenGroupServer.Application.Dto;
using LiebenGroupServer.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.DataAccess.Repostories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task AddAsync(Order order, List<OrderLineItem> lineItems);
        Task UpdateAsync(Order order, List<OrderLineItem> lineItems);
        Task DeleteAsync(Guid id);
    }
}
