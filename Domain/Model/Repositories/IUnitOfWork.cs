using System.Threading.Tasks;

namespace Supermarket.API.Domain.Model.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}