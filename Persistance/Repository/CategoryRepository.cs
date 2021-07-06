using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Model;
using Supermarket.API.Domain.Model.Services;
using Supermarket.API.Persistance.Context;

namespace Supermarket.API.Persistance.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDBContext context) : base(context)
        {
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();

            // how it is to write with an external keyboard
            
        }
    }
}