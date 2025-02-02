using LiebenGroupServer.DataAccess.DatabaseContext;
using LiebenGroupServer.DataAccess.Models;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LiebenGroupServer.DataAccess.Repostories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly DBContext _dbContext;

        public OrderRepository(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task AddAsync(Order order, List<OrderLineItem> lineItems)
        {
            if (lineItems == null || lineItems.Count == 0)
                throw new ArgumentException("An order must contain at least one line item.");

            order.Items.AddRange(lineItems);

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Order? order = await GetByIdAsync(id);

            if (order != null)
            {
                _dbContext.Orders.Remove(order);
            }

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbContext.Orders
                .Include(x => x.Items)
                .ThenInclude(p => p.Product)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Orders.Include(x => x.Items)
                .ThenInclude(p => p.Product)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Order order, List<OrderLineItem> lineItems)
        {
            Order? existingOrder = await _dbContext.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == order.Id);

            if (existingOrder == null)
                throw new KeyNotFoundException("Order not found.");

            
            existingOrder.OrderDate = order.OrderDate;
            
            existingOrder.Items.RemoveAll(existingItem =>
                !lineItems.Any(u => u.ProductId == existingItem.ProductId));

            foreach (var updatedItem in lineItems)
            {
                OrderLineItem? existingItem = existingOrder.Items.FirstOrDefault(i => i.ProductId == updatedItem.ProductId);
                if (existingItem == null)
                {
                    existingOrder.Items.Add(updatedItem);
                }
                else
                {
                    existingItem.UpdateQuantityAndPrice(updatedItem.Quantity, updatedItem.UnitPrice);
                }
            }

            await _dbContext.SaveChangesAsync(); 
        }
    }
    }
