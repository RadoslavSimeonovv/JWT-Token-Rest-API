using AppGreat.Services.DTO_s;
using AppGreat_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppGreat_API.Mappers
{
    internal static class ProductMapper
    {
        internal static ProductViewModel MapProductToVM(this ProductDTO productDTO)
        {
            var productVM = new ProductViewModel();
            productVM.Id = productDTO.Id;
            productVM.Name = productDTO.Name;
            productVM.Price = productDTO.Price;
            productVM.ImageURL = productDTO.ImageURL;

            return productVM;
        }

        internal static ProductDTO MapProductVMToDTO(this ProductViewModel productVM)
        {
            var productDTO = new ProductDTO();
            productDTO.Id = productVM.Id;
            productDTO.Name = productVM.Name;
            productDTO.Price = productVM.Price;
            productDTO.ImageURL = productVM.ImageURL;

            return productDTO;
        }

    }
}
