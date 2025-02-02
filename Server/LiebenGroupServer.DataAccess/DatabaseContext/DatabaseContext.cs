using LiebenGroupServer.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LiebenGroupServer.DataAccess.DatabaseContext
{
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderLineItem> LineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            modelBuilder.Entity<OrderLineItem>()
                .HasKey(ol => new { ol.ProductId, ol.OrderId });

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderLineItems)
                .WithOne(ol => ol.Product)
                .HasForeignKey(ol => ol.ProductId);
        }
    }
}
