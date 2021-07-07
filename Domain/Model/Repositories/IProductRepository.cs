using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.DTOs;

namespace Supermarket.API.Domain.Model.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddProduct(Product product);
    }
}