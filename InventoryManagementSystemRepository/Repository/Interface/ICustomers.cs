using InventoryManagementSystemRepository.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystemRepository.Repository.Interface
{
    public interface ICustomers
    {
        public void AddCustomer(Customers customer);
        public void EditCustomer(Customers customer);
        public Customers FindCustomerById(int Id);
        public IEnumerable GetCustomerDetails();
        public void RemoveCustomer(int Id);
    }
}
