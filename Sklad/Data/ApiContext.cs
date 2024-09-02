using Microsoft.EntityFrameworkCore;
using Sklad.Model;

namespace Sklad.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) 
        :base(options)
        { 
    
        }   
    
    }
}
