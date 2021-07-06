using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Model.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync(); 
        Task AddAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        void Update(Category category);
        void Delete(Category category);
    }
}