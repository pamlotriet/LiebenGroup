using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.DataAccess.Models
{
    public class OrderLineItem
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; } 
        public decimal TotalPrice => Quantity * UnitPrice;
        public Order Order { get; private set; }
        public Product Product { get; private set; }
        public void UpdateQuantityAndPrice(int quantity, decimal unitPrice)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
