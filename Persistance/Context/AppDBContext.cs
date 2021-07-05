using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Model;

namespace Supermarket.API.Persistance.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options): base(options)    
        {           
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}