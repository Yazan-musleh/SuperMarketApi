using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.DTOs;

namespace Supermarket.API.Domain.Model.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<ProductDto> AddProduct(Product product);
    }
}