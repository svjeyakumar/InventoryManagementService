using InventoryManagementSystem.BusinessLayer.Interface;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository.Interface;
using System.Collections;


namespace InventoryManagementSystem.BusinessLayer
{
    public class CustomerDetailsBL : ICustomerDetails
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerDetailsBL(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public void EditCustomer(Customer customer)
        {
            _customerRepository.EditCustomer(customer);
        }

        public Customer FindCustomerById(int Id)
        {
            return _customerRepository.FindCustomerById(Id);
        }

        public IEnumerable GetCustomerDetails()
        {
            return _customerRepository.GetCustomerDetails();
        }

        public void RemoveCustomer(int Id)
        {
            _customerRepository.RemoveCustomer(Id);
        }
    }
}
