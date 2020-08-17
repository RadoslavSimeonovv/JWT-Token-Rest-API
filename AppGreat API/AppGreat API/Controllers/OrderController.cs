using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGreat.Services.Contracts;
using AppGreat_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppGreat_API.Mappers;
using AppGreat.Data.Entities;
using AppGreat.Services.Helpers;
using AppGreat_API.Helpers;

namespace AppGreat_API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;  
        }


        /*
         * Get all user orders
         * by using the appropriate service method
         * and then we use the external api to
         * return the correct currency to the user
         * http://localhost:5000/api/orders/ - request URL
         */
        [Authorize]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUserOrders()
        {
            var user = (User)HttpContext.Items["User"];

            var orders = await this.orderService.GetAllUserOrders(user.Id);
            foreach (var order in orders)
            {
                order.TotalPrice *= ExchangeRatesAPI.ExchangeRate(user.CurrencyCode.ToString());
            }

            var userOrdersVM = orders
                .Select(o => o.MapOrderToVM())
                .ToList();

            return Ok(userOrdersVM);
        }


        /*
       * Create a new user order
       * by using the appropriate service method
       * and then we use the external api to
       * return the correct currency to the user
       * http://localhost:5000/api/orders/ - request URL
       */
        [Authorize]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateOrder([FromBody] string products)
        {
            var user = (User)HttpContext.Items["User"];
            try
            {
                var order = await orderService.CreateOrder(user.Id, products);
                order.TotalPrice *= ExchangeRatesAPI.ExchangeRate(user.CurrencyCode.ToString());

                return Created("Post", order);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * Change order status
         * by using the appropriate service method
         * http://localhost:5000/api/orders/id - request URL
         */
        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> ChangeOrderStatus(int id, [FromBody] string status)
        {
            try
            {
                var userId = ((User)HttpContext.Items["User"]).Id;
                var order = await orderService.ChangeOrderStatus(id, userId, status);
                return Ok(order);
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
