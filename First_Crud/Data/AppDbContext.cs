using First_Crud.Modals;
using Microsoft.EntityFrameworkCore;

namespace First_Crud.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products => Set<Product>();
    }
}
