﻿using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

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
