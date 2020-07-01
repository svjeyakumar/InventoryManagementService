using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystemRepository.Models
{
    public class Users
    {
        [Key]
        public int UId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
