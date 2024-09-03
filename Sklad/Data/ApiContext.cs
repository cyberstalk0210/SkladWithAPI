using Microsoft.EntityFrameworkCore;
using Sklad.Model;

namespace Sklad.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=45.80.68.26;Port=5432;Database=postgres;Username=postgres;Password=Banek12!;");
        }

        public ApiContext(DbContextOptions<ApiContext> options) 
        :base(options)
        { 
    
        }   
    
    }
}
