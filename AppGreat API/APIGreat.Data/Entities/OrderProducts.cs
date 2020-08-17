using System;
using System.Collections.Generic;
using System.Text;

namespace AppGreat.Data.Entities
{
    public class OrderProducts
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }

    }
}
