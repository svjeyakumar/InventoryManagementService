using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    public class Customerdetails
    {
        public int CustomerId { get; set; }
        public string Filepath { get; set; }
        public IFormFile fileImage { get; set; }

    }
}
