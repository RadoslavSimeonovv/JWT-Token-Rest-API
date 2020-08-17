using System;
using System.Collections.Generic;
using System.Text;

namespace AppGreat.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }

    }
}
