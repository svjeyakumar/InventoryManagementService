using Microsoft.AspNetCore.Http;

namespace InventoryManagementSystem.Models
{
    public class Customerdetails
    {
        public int CustomerId { get; set; }
        public string Filepath { get; set; }
        public IFormFile fileImage { get; set; }

    }
}
