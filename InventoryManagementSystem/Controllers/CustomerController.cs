using System;
using System.Collections.Generic;
using InventoryManagementSystem.BusinessLayer.Interface;
using InventoryManagementSystem.Models;
using InventoryManagementSystemRepository.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagementSystem.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]        
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDetails _blCustomerDetails;
        private readonly IDistributedCache _distributedCache;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
                
        public CustomerController(ICustomerDetails blCustomerDetails, IDistributedCache distributedCache,ILogger<CustomerController> logger)
        {            
            _blCustomerDetails = blCustomerDetails;
            _distributedCache = distributedCache;
            _logger = logger;
        }        

        [HttpGet]
        public ActionResult<Customer> GetCustomerDetails()
        {
            List<Customer> cust;
            string key = Consts.RedisGetCustomer;
            try
            {
                _logger.LogInformation("Get Customer Details Started");
                if(string.IsNullOrEmpty(_distributedCache.GetString(key)))
                {
                    cust = (List<Customer>)_blCustomerDetails.GetCustomerDetails();
                    var option = new DistributedCacheEntryOptions();
                    option.SetSlidingExpiration(TimeSpan.FromMinutes(1));
                    _distributedCache.SetString(key, System.Text.Json.JsonSerializer.Serialize<List<Customer>>(cust), option);                
                }
                else
                {
                    cust = System.Text.Json.JsonSerializer.Deserialize<List<Customer>>(_distributedCache.GetString(key));
                }
                
            }
            catch(StackExchange.Redis.RedisConnectionException)
            {
                _logger.LogInformation("Get Customer details Error");
                cust = (List<Customer>)_blCustomerDetails.GetCustomerDetails();
            }
            return Ok(cust);
        }
        // GET api/<CustomerController>/5
        [HttpGet("{id:int}")]
        public ActionResult<Customer> GetCustomerDetails(int Id)
        {
            var Cust = _blCustomerDetails.FindCustomerById(Id);
            if (Cust == null)
                return NotFound();
            return Cust;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<Customer> PostCustomerDetails(Customer customer)
        {
            try
            {
                _blCustomerDetails.AddCustomer(customer);
                return CreatedAtAction(Consts.GetCustomerDetails, new {id = customer.CustomerId }, customer);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult PutCustomerDetails(int id, Customer customer)
        {
            if(id != customer.CustomerId)
            {
                return BadRequest();
            }
            try
            {
                _blCustomerDetails.EditCustomer(customer);
            }
            catch(DbUpdateConcurrencyException)
            {
                if (_blCustomerDetails.FindCustomerById(id) == null)
                {
                    return NotFound();
                }
                else
                    BadRequest();
            }
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> DeleteCustomer(int id)
        {
            try
            {
                var Cust = _blCustomerDetails.FindCustomerById(id);
                if(Cust == null)
                {
                    return NotFound();
                }
                _blCustomerDetails.RemoveCustomer(id);
                return Cust;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}
