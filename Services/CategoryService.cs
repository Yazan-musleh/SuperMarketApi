using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Model;
using Supermarket.API.Domain.Model.Repositories;
using Supermarket.API.Domain.Model.Services;
using Supermarket.API.Domain.Model.Services.Communication;
using Supermarket.API.Domain.Services;

namespace Supermarket.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;

        }


        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _repository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(category);
            }
            catch (System.Exception ex)
            {
                return new SaveCategoryResponse($"An error occurred while saving the category {ex.Message}");
            }
        }

        public async Task<SaveCategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _repository.GetByIdAsync(id);

            if (existingCategory is null)
            {
                return new SaveCategoryResponse("Category Not Found. 404");
            }

            existingCategory.Name = category.Name;
            

            try
            {
                _repository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                
                return new SaveCategoryResponse(existingCategory);
            }
            catch (System.Exception ex)
            {
                
                return new SaveCategoryResponse($"An Error Occurred when updating the category: {ex.Message}");
            }
        }
    }
}