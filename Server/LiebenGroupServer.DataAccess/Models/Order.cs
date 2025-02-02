using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.DataAccess.Models
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public List<OrderLineItem> Items { get; private set; } = new();
        public DateTime OrderDate { get; private set; }
        public decimal TotalAmount => Items.Sum(i => i.TotalPrice); 
    }
}
