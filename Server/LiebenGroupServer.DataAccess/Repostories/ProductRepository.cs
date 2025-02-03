using LiebenGroupServer.DataAccess.DatabaseContext;
using LiebenGroupServer.DataAccess.Models;
using LiebenGroupServer.DataAccess.Repostories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LiebenGroupServer.DataAccess.Repostories
{
    public class ProductRepository : IProductRepository
    {

        private readonly DBContext _context;

        public ProductRepository(DBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();    
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
