using AppGreat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppGreat_API.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<ProductViewModel> OrderProducts { get; set; }
        public int UserId { get; set; }

    }
}
