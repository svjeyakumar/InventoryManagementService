﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystemRepository.Models
{
    public class Customers
    {
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Display(Name = "CustomerTypeId")]
        public int CustomerTypeId { get; set; }
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }


    }
    public class CustomerList
    {
        public ICollection<Customers> CustomerDetails { get; set; }
    }
}
