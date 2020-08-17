using AppGreat.Services.DTO_s;
using AppGreat_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppGreat_API.Mappers
{
    internal static class OrderMapper
    {
        internal static OrderViewModel MapOrderToVM(this OrderDTO orderDTO)
        {
            var orderVM = new OrderViewModel();
            orderVM.Id = orderDTO.Id;
            orderVM.TotalPrice = orderDTO.TotalPrice;
            orderVM.Status = orderDTO.Status;
            orderVM.CreatedAt = orderDTO.CreatedAt;
            orderVM.UserId = orderDTO.UserId;

            orderVM.OrderProducts = orderDTO.OrderProducts
              .Select(op => op.MapProductToVM())
              .ToList();

            return orderVM;
        }

        internal static OrderDTO MapOrderVMToDTO(this OrderViewModel orderVM)
        {
            var orderDTO = new OrderDTO();
            orderDTO.Id = orderVM.Id;
            orderDTO.TotalPrice = orderVM.TotalPrice;
            orderDTO.CreatedAt = orderVM.CreatedAt;
            orderDTO.UserId = orderVM.UserId;

            return orderDTO;
        }

    }
}
