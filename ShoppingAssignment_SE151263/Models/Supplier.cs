using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingAssignment_SE151263.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
