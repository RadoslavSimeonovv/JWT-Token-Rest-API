using AppGreat.Data.Entities;
using AppGreat.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppGreat.Services.Mappers;

namespace AppGreat.Services.Mappers
{
    internal static class OrderMapper
    {
        internal static OrderDTO MapOrderToDTO(this Order order)
        {
            var orderDto = new OrderDTO();
            orderDto.Id = order.Id;
            orderDto.TotalPrice = order.TotalPrice;
            orderDto.Status = order.Status;
            orderDto.CreatedAt = order.CreatedAt;
            orderDto.UserId = order.UserId;
            orderDto.OrderProducts = order.OrderProducts
                .Select(op => ProductMapper.MapProductToDTO(op.Product))
                .ToList();

            return orderDto;
        }
    }
}
