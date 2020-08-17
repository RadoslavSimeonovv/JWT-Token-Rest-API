using AppGreat.Services.Contracts;
using AppGreat.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppGreat.Services.Mappers;
using APIGreat.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AppGreat.Data.Entities;

namespace AppGreat.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppGreatContext _appGreatContext;
        public OrderService(AppGreatContext appGreatContext)
        {
            this._appGreatContext = appGreatContext;
        }

        /* 
         * Change status order method 
         * Gets the order id from the request, the current logged userId and the new status 
         * which will be parsed to enum and then ToString() so it can be saved in the database.            
          */
        public async Task<OrderDTO> ChangeOrderStatus(int orderID, int userID, string newStatus)
        {
            var order = await _appGreatContext.Orders
               .Include(o => o.OrderProducts)
               .ThenInclude(p => p.Product)
               .FirstOrDefaultAsync(o => o.Id == orderID);

            if (order == null)
            {
                throw new ArgumentNullException("Order doesn't exist!");
            }

            var user = await _appGreatContext.Users
               .FirstOrDefaultAsync(u => u.Id == userID);

            if (user == null)
            {
                throw new ArgumentNullException("User doesn't exist!");
            }


            StatusEnum status = (StatusEnum) Enum.Parse(typeof(StatusEnum), newStatus, true);
            order.Status = status.ToString();
            await _appGreatContext.SaveChangesAsync();

            return order.MapOrderToDTO();
        }



        /*
         * Create order method
         * It uses the current user ID and a string of the products which 
         * is passed through the request body separated by a comma. After the string is split by 
         * a comma so we can receive the products, check if they exist in the database
         * and if they do, add their product and order id's separately in the OrderProducts table
         * We also add each product price to the total order price and save everything in the database.
         */
        public async Task<Order> CreateOrder(int userID, string products)
        {
            var user = await _appGreatContext.Users
                .FirstOrDefaultAsync(u => u.Id == userID);

            List<string> productsInString = products.Split(',').ToList();

            if (user == null)
            {
                throw new ArgumentNullException("User doesn't exist!");
            }

            var newOrderStatus = StatusEnum.New.ToString();

            var newOrder = new Order
            {             
                Status = newOrderStatus,
                CreatedAt = DateTime.UtcNow,
                UserId = userID
            };

            await _appGreatContext.Orders.AddAsync(newOrder);
            await _appGreatContext.SaveChangesAsync();


            foreach (var product in productsInString)
            {
                var productExists = await _appGreatContext.Products
                .FirstOrDefaultAsync(p => p.Name == product);

                if(productExists != null)
                {
                    newOrder.TotalPrice += productExists.Price;

                   await _appGreatContext.OrderProducts.AddAsync(
                   new OrderProducts
                   {
                       ProductId = productExists.Id,
                       OrderId = newOrder.Id
                   });
                }
            }

            await _appGreatContext.SaveChangesAsync();

            return newOrder;
        }


        /*
         *  Get all user orders
         *  Retrieve all the current user orders 
         *  after we check in the orders table with 
         *  the given user ID.
         */
        public async Task<IEnumerable<OrderDTO>> GetAllUserOrders(int userID)
        {
            var user = await _appGreatContext.Users
                .FirstOrDefaultAsync(u => u.Id == userID);

            if(user == null)
            {
                throw new ArgumentNullException("User doesn't exist!");
            }

            var userOrders = await _appGreatContext.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(p => p.Product)
                .Where(o => o.UserId == userID)
                .Select(o => o.MapOrderToDTO())
                .ToListAsync();

            return userOrders;

        }
    }
}
