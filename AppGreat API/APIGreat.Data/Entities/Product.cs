using System;
using System.Collections.Generic;
using System.Text;

namespace AppGreat.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime? DeletedOn { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }

    }
}
