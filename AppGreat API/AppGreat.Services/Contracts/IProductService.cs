using AppGreat.Data.Entities;
using AppGreat.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGreat.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductDTO> GetProduct(int id);
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> CreateProduct(ProductDTO productDTO);
        Task<bool> DeleteProduct(int id);

    }
}
