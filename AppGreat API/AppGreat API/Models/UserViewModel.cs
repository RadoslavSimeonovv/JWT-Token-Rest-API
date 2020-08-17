using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppGreat_API.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string CurrencyCode { get; set; }
    }
}
