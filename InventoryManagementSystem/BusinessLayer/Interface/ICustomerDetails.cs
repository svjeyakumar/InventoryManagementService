using InventoryManagementSystem.Models;
using System.Collections;


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
