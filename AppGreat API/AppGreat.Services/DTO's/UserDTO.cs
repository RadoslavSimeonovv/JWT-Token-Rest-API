using System;
using System.Collections.Generic;
using System.Text;

namespace AppGreat.Services.DTO_s
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string CurrencyCode { get; set; }
        public ICollection<OrderDTO> Orders { get; set; }
    }
}
