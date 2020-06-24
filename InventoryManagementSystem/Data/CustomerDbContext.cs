using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Data
{
    public class CustomerDbContext:DbContext
    {
        public DbSet<Customer> Customers  { get; set; }
        public DbSet<User> Users { get; set; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext>options):base(options)
        {

        }
    }
}
