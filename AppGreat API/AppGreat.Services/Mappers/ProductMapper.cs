using AppGreat.Data.Entities;
using AppGreat.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppGreat.Services.Mappers
{
    internal static class ProductMapper
    {
        internal static ProductDTO MapProductToDTO(this Product product)
        {
            var productDTO = new ProductDTO();
            productDTO.Id = product.Id;
            productDTO.Name = product.Name;
            productDTO.Price = product.Price;
            productDTO.ImageURL = product.ImageURL;

       
            return productDTO;
        }

        internal static Product MapProductToModel(this ProductDTO productDTO)
        {
            var product = new Product();
            product.Id = productDTO.Id;
            product.Name = productDTO.Name;
            product.Price = productDTO.Price;
            product.ImageURL = productDTO.ImageURL;


            return product;
        }
    }
}
