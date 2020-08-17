using System;
using System.Collections.Generic;
using System.Text;

namespace AppGreat.Services.DTO_s
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public ICollection<String> OrderProducts { get; set; }

    }
}
