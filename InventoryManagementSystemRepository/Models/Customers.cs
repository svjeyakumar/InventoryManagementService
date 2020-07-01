using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystemRepository.Models
{
    public class Customers
    {
        public int CustId { get; set; }
        [Required]
        public string CustName { get; set; }
        [Display(Name = "CustomerTypeId")]
        public int CustTypeId { get; set; }
        [Display(Name = "Street Address")]
        public string CusAddress { get; set; }
        public string CusCity { get; set; }
        public string CusState { get; set; }
        [Display(Name = "Zip Code")]
        public string CusZipcode { get; set; }
        public string CustPhone { get; set; }
        public string CustEmail { get; set; }
        [Display(Name = "Contact Person")]
        public string CustContactPerson { get; set; }


    }
    public class CustList
    {
        public ICollection<Customers> CustomerDetails { get; set; }
    }
}
