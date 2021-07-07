using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Model;
using Supermarket.API.Domain.Model.Services.Communication;

namespace Supermarket.API.Domain.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ListAsync();
        Task<Response<Category>> SaveAsync(Category category);
        Task<Response<Category>> UpdateAsync(int id, Category category);
        Task<Response<Category>> DeleteAsync(int id);         
    }
}