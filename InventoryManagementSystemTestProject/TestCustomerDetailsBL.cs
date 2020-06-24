using InventoryManagementSystem.BusinessLayer;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository.Interface;
using Moq;
using NUnit.Framework;


namespace InventoryManagementSystemTestProject
{
    [TestFixture]
    public class TestCustomerDetailsBL
    {
        private CustomerDetailsBL _blCustomerdetails;
        private Mock<ICustomerRepository> _CustomerRepository;
               

        [SetUp]
        public void Setup()
        {
            _CustomerRepository = new Mock<ICustomerRepository>();
            _blCustomerdetails = new CustomerDetailsBL(_CustomerRepository.Object);
        }

        [Test]
        public void AddCustomerVerified()
        {
            var cus = new Customer();
            _blCustomerdetails.AddCustomer(cus);
            _CustomerRepository.Verify(q => q.AddCustomer(cus), Times.Once());            
        }
        [Test]
        public void EditVerified()
        {
            var cus = new Customer();
            _blCustomerdetails.EditCustomer(cus);
            _CustomerRepository.Verify(q => q.EditCustomer(cus), Times.Once());
        }
        [Test]
        public void DeleteVerified()
        {
            int id = 1;
            var cus = new Customer() { CustomerId = id };
            _CustomerRepository.Setup(q => q.FindCustomerById(id)).Returns(cus);
            _blCustomerdetails.RemoveCustomer(id);
            _CustomerRepository.Verify(q => q.RemoveCustomer(id), Times.Once());
        }
        [Test]
        public void FindByCustomerIdVerified()
        {
            int id = 1;
            _blCustomerdetails.FindCustomerById(id);
            _CustomerRepository.Verify(q => q.FindCustomerById(id), Times.Once());

        }
        [Test]
        public void GetCustomerDetailsVerified()
        {
            _blCustomerdetails.GetCustomerDetails();
            _CustomerRepository.Verify(q => q.GetCustomerDetails(), Times.Once());
        }
    }
}