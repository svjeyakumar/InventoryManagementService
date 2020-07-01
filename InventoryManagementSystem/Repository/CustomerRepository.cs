using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace InventoryManagementSystem.Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly CustomerDbContext _customerDBContext;
        public CustomerRepository(CustomerDbContext cusDbContext)
        {
            _customerDBContext = cusDbContext;
        }
        public void AddCustomer(Customer customer)
        {
            _customerDBContext.Customers.Add(customer);
            _customerDBContext.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {         
            var cust = _customerDBContext.Customers.AsNoTracking().Where(q => q.CustomerId == customer.CustomerId);
            foreach (var cus in cust)
            {
                if ((customer.CustomerId == cus.CustomerId))
                {
                    _customerDBContext.Customers.Remove(cus);
                }
            }
            _customerDBContext.Attach(customer);
            IEnumerable<EntityEntry> noChangeEntities = _customerDBContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Unchanged);
            foreach (EntityEntry cusEE in noChangeEntities)
            {
                cusEE.State = EntityState.Modified;
            }
            _customerDBContext.Entry(customer).State = EntityState.Modified;
            _customerDBContext.SaveChanges();
        }

        public Customer FindCustomerById(int Id)
        {
            var findcustomer = _customerDBContext.Customers.AsNoTracking().Where(p => p.CustomerId == Id).FirstOrDefault();
            return findcustomer;
        }

        public IEnumerable GetCustomerDetails()
        {
            return _customerDBContext.Customers.ToList();
        }

        public void RemoveCustomer(int Id)
        {
            var removeCustomer = _customerDBContext.Customers.Where(c => c.CustomerId == Id).FirstOrDefault();
            _customerDBContext.Customers.Remove(removeCustomer);
            _customerDBContext.SaveChanges();
        }
    }
}
