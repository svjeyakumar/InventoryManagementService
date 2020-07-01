using InventoryManagementSystemRepository.Models;
using System.Collections;

namespace InventoryManagementSystemRepository.Repository.Interface
{
    public interface ICustomers
    {
        public void AddInvoice(Customers customer);
        public void EditInvoice(Customers customer);
        public Customers FindInvoiceById(int Id);
        public IEnumerable GetInvoiceDetails();
        public void RemoveInvoice(int Id);
    }
}
