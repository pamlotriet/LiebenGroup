using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.DataAccess.Models
{
    public class Order
    {
        public Guid Id { get;  set; }
        public List<OrderLineItem> Items { get;  set; } = new();
        public DateTime OrderDate { get;  set; }
        public decimal TotalAmount => Items.Sum(i => i.TotalPrice); 
    }
}
