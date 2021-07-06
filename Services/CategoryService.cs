using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Model;
using Supermarket.API.Domain.Model.Services;
using Supermarket.API.Domain.Model.Services.Communication;
using Supermarket.API.Domain.Services;

namespace Supermarket.API.Services
{
    public class CategoryService : Domain.Services.ICategoryService
    {
        private readonly Domain.Model.Services.ICategoryRepository _repository;

        public CategoryService(Domain.Model.Services.ICategoryRepository repository)
        {
            this._repository = repository;

        }


        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}