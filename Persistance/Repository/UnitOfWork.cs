using System.Threading.Tasks;
using Supermarket.API.Domain.Model.Repositories;
using Supermarket.API.Persistance.Context;

namespace Supermarket.API.Persistance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;

        public UnitOfWork(AppDBContext context)
        {
            this._context = context;
        }
        
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}