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

        public async Task<CategoryResponse> DeleteAsync(int id)
        {

            var existingCategory = await _repository.GetByIdAsync(id);

            if (existingCategory == null)
            {
                return new CategoryResponse("Character is Not Found. 404");
            }

            try
            {
                _repository.Delete(existingCategory);

                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (System.Exception ex) 
            {
                return new CategoryResponse($"An error occurred while deleting the category {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _repository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (System.Exception ex)
            {
                return new CategoryResponse($"An error occurred while saving the category {ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _repository.GetByIdAsync(id);

            if (existingCategory is null)
            {
                return new CategoryResponse("Category Not Found. 404");
            }

            existingCategory.Name = category.Name;
            

            try
            {
                _repository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                
                return new CategoryResponse(existingCategory);
            }
            catch (System.Exception ex)
            {
                
                return new CategoryResponse($"An Error Occurred when updating the category: {ex.Message}");
            }
        }
    }
}