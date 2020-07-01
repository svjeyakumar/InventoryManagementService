using InventoryManagementSystemRepository.Models;
using InventoryManagementSystemRepository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystemRepository.Repository
{
    public class CustomersRepository : ICustomers
    {
        private readonly CustomerInvoiceDbContext _customerDBContext;
        public CustomersRepository(CustomerInvoiceDbContext cusDbContext)
        {
            _customerDBContext = cusDbContext;
        }

        public void AddInvoice(Customers customer)
        {
            _customerDBContext.Customers.Add(customer);
            _customerDBContext.SaveChanges();
        }

        public void EditInvoice(Customers customer)
        {
            var cust = _customerDBContext.Customers.AsNoTracking().Where(q => q.CustId == customer.CustId);
            foreach (var cus in cust)
            {
                if ((customer.CustId == cus.CustId))
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

        public Customers FindInvoiceById(int Id)
        {
            var findcustomer = _customerDBContext.Customers.AsNoTracking().Where(p => p.CustId == Id).FirstOrDefault();
            return findcustomer;
        }

        public IEnumerable GetInvoiceDetails()
        {
            return _customerDBContext.Customers.ToList();
        }

        public void RemoveInvoice(int Id)
        {
            var removeCustomer = _customerDBContext.Customers.Where(c => c.CustId == Id).FirstOrDefault();
            _customerDBContext.Customers.Remove(removeCustomer);
            _customerDBContext.SaveChanges();
        }
    }
}
