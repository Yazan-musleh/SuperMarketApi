using Supermarket.API.Persistance.Context;

namespace Supermarket.API.Persistance
{
    public abstract class BaseRepository
    {
        protected readonly AppDBContext _context;
        public BaseRepository(AppDBContext context)
        {
            this._context = context;
        }
    }
}