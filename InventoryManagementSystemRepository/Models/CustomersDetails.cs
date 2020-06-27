using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystemRepository.Models
{
    public class Customersdetails
    {
        public int CustomerId { get; set; }
        public string Filepath { get; set; }
        public IFormFile fileImage { get; set; }

    }
}
