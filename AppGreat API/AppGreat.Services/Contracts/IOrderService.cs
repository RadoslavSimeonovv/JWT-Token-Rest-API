using AppGreat.Data.Entities;
using AppGreat.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGreat.Services.Contracts
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(/*OrderDTO orderDTO,*/ int userID, string products);
        Task<IEnumerable<OrderDTO>> GetAllUserOrders(int userID);
        Task<OrderDTO> ChangeOrderStatus(int orderID, int userID, string newStatus);
    }
}
