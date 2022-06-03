using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingAssignment_SE151263.Models
{
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; }

        [StringLength(50)]
        public string? Password { get; set; }

        [StringLength(30)]
        public string? ContactName { get; set; }

        [StringLength(60)]
        public string? Address { get; set; }

        [StringLength(24)]
        public string? Phone { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}