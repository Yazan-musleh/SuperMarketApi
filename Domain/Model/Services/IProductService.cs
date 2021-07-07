using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Model.Services.Communication;
using Supermarket.API.DTOs;

namespace Supermarket.API.Domain.Model.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<Response<Product>> AddProduct(Product product);
    }
}