using Microsoft.AspNetCore.Http;

namespace InventoryManagementSystemRepository.Models
{
    public class Customersdetails
    {
        public int CustomerTypeId { get; set; }
        public string CustFilepath { get; set; }
        public IFormFile CustfileImage { get; set; }

    }
}
