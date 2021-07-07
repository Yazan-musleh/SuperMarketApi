using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Model;
using Supermarket.API.Domain.Model.Repositories;
using Supermarket.API.Domain.Model.Services;
using Supermarket.API.Domain.Model.Services.Communication;
using Supermarket.API.DTOs;

namespace Supermarket.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;

        }

        public async Task<Response<Product>> AddProduct(Product product)
        {
            try
            {

                await _repository.AddProduct(product);
                await _unitOfWork.CompleteAsync();


                return new Response<Product>(product);
            }
            catch (System.Exception ex)
            {

                return new Response<Product>($"there was an error Adding product: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _repository.ListAsync();
        }
    }
}