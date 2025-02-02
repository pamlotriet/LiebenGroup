using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiebenGroupServer.DataAccess.Models
{
    public class Product
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public decimal Price { get;  set; }
        public List<OrderLineItem> OrderLineItems { get; private set; } = new();
    }
}
