using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemRepository.Models
{
    public class CustomerInvoiceDbContext:DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Users> Users { get; set; }
        public CustomerInvoiceDbContext(DbContextOptions<CustomerInvoiceDbContext> options) : base(options)
        {

        }
    }
}
