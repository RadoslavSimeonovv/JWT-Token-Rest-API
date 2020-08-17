using AppGreat.Services.DTO_s;
using AppGreat_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppGreat_API.Mappers
{
    internal static class UserMapper
    {
        internal static UserViewModel MapUserDTOToVM(this UserDTO userDTO)
        {
            var userVM = new UserViewModel();
            userVM.Id = userDTO.Id;
            userVM.Username = userDTO.Username;
            userVM.Password = userDTO.Password;
            userVM.CurrencyCode = userDTO.CurrencyCode;

            return userVM;
        }

        internal static UserDTO MapUserVMToDTO(this UserViewModel userVM)
        {
            var userDTO = new UserDTO();
            userDTO.Id = userVM.Id;
            userDTO.Username = userVM.Username;
            userDTO.Password = userVM.Password;
            userDTO.CurrencyCode = userVM.CurrencyCode;

            return userDTO;
        }
    }
}
