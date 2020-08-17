using APIGreat.Data;
using AppGreat.Services.Contracts;
using AppGreat.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGreat.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace AppGreat.Services
{
    public class ProductService : IProductService
    {
        private readonly  AppGreatContext _appGreatContext;
        public ProductService(AppGreatContext appGreatContext)
        {
            this._appGreatContext = appGreatContext;
        }

        /*
         * Create product method
         * We create the product through the request body
         * adding the name, price and imageURL.
         */
        public async Task<ProductDTO> CreateProduct(ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                throw new ArgumentNullException("Product doesn't exist!");
            }

            var product = productDTO.MapProductToModel();

            await _appGreatContext.Products.AddAsync(product);
            await _appGreatContext.SaveChangesAsync();

            return productDTO;
        }

       /*
       * Delete product by ID method
       * Delete a product from the table
       * The deletion is by making a DeletedOn property
       * of the product equal to the current date.
       */

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _appGreatContext.Products
              .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException("Product doesn't exist!");
            }

            product.DeletedOn = DateTime.UtcNow;
            await this._appGreatContext.SaveChangesAsync();

            return true;
        }

        /*
        * Retrieve and return all products from the database which are not deleted
        */

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var productsDTO = await _appGreatContext.Products
               .Where(p => p.DeletedOn == null)
               .Select(p => p.MapProductToDTO())
               .ToListAsync();

            return productsDTO;
        }


        /*
        * Retrieve and return a product by ID
        */
        public async Task<ProductDTO> GetProduct(int id)
        {
            var product = await _appGreatContext.Products
               .FirstOrDefaultAsync(p => p.Id == id);

            return product.MapProductToDTO();
        }
    }
}
