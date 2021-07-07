using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Model;
using Supermarket.API.Domain.Model.Repositories;
using Supermarket.API.Domain.Model.Services.Communication;
using Supermarket.API.DTOs;
using Supermarket.API.Persistance.Context;

namespace Supermarket.API.Persistance.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(AppDBContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        
    }
}