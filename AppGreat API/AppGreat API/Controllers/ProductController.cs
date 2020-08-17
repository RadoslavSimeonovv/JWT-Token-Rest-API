using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGreat.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppGreat_API.Mappers;
using AppGreat_API.Models;
using AppGreat.Services.Helpers;
using AppGreat.Data.Entities;

namespace AppGreat_API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IUserService userService;

        public ProductController(IProductService productService, IUserService userService)
        {
            this.productService = productService;
            this.userService = userService;
        }


        /*
        * Retrieve all product from the database
        * by using the appropriate service method
        * http://localhost:5000/api/products/ - request URL
        */
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await this.productService.GetAllProducts();
            var productsVM = products
                .Select(p => p.MapProductToVM())
                .ToList();

            return Ok(productsVM);
        }


        /*
        * Retrieve a product from the database
        * by id by using the appropriate service method
        * http://localhost:5000/api/products/id - request URL
        */
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var productDTO = await productService.GetProduct(id);
                   
                return Ok(productDTO.MapProductToVM());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /*
        * Create a new product  
        * by using the appropriate service method
        * http://localhost:5000/api/products/ - request URL
        */
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductViewModel productVM)
        {
            try
            {
                var productDTO = productVM.MapProductVMToDTO();
                var product = await productService.CreateProduct(productDTO);

                return Created("Post", product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
       * Delete an existing product
       * by using the appropriate service method
       * http://localhost:5000/api/products/id - request URL
       */
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.productService.DeleteProduct(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
