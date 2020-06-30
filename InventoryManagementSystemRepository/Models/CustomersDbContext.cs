using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemRepository.Models
{
    public class CustomersDbContext:DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Users> Users { get; set; }
        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options)
        {

        }
    }
}
