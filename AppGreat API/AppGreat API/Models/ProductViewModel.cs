using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppGreat_API.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime? DeletedOn { get; set; }

    }
}
