using Microsoft.AspNetCore.Http;

namespace InventoryManagementSystemRepository.Models
{
    public class Customersdetails
    {
        public int CustomerId { get; set; }
        public string Filepath { get; set; }
        public IFormFile fileImage { get; set; }

    }
}
