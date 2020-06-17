using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerDbContext cusdbcon;
        public CustomerController(CustomerDbContext cusdbcontext)
        {
            cusdbcon = cusdbcontext;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return cusdbcon.Customers;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}",Name ="Get")]
        public Customer Get(int Id)
        {
            var Cust = cusdbcon.Customers.Find(Id);
            return Cust;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            cusdbcon.Customers.Add(customer);
            cusdbcon.SaveChanges();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            var entity = cusdbcon.Customers.Find(id);
            entity.CustomerName = customer.CustomerName;
            entity.CustomerTypeId = customer.CustomerTypeId;
            entity.Address = customer.Address;
            entity.City = customer.City;
            entity.ContactPerson = customer.ContactPerson;
            entity.State = customer.State;
            entity.Phone = customer.Phone;
            entity.Email = customer.Email;
            entity.Zipcode = customer.Zipcode;
            cusdbcon.SaveChanges();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customer = cusdbcon.Customers.Find(id);
            cusdbcon.Customers.Remove(customer);
            cusdbcon.SaveChanges();
        }
    }
}
