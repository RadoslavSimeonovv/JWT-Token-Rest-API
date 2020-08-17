using AppGreat.Data.Entities;
using AppGreat.Services.DTO_s;
using AppGreat.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGreat.Services.Contracts
{
    public interface IUserService
    {
        Task<UserDTO> RegisterUser(UserDTO userDTO);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
