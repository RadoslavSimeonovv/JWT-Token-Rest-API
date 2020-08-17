using AppGreat.Data.Entities;
using AppGreat.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppGreat.Services.Mappers
{
    internal static class UserMapper
    {
        internal static UserDTO MapUserToDTO(this User user)
        {
            var userDTO = new UserDTO();
            userDTO.Id = user.Id;
            userDTO.Username = user.Username;
            userDTO.Password = user.Password;
            userDTO.CurrencyCode = user.CurrencyCode;

            return userDTO;
        }

        internal static User MapUserDTOToModel(this UserDTO userDTO)
        {
            var user = new User();
            user.Id = userDTO.Id;
            user.Username = userDTO.Username;
            user.Password = userDTO.Password;
            user.CurrencyCode = userDTO.CurrencyCode;

            return user;
        }


    }
}
