using Microsoft.EntityFrameworkCore;
using Session6.Models;

namespace Session6.AppDbContext
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> Context) : base(Context)
        {
        }

        public DbSet<Product> HealthProducts { get; set; }
    }
}
