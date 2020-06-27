using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
