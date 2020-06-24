using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.BusinessLayer.Interface
{
    public interface ICustomerDetails
    {
        public void AddCustomer(Customer customer);
        public void EditCustomer(Customer customer);
        public Customer FindCustomerById(int Id);
        public IEnumerable GetCustomerDetails();
        public void RemoveCustomer(int Id);
    }
}
