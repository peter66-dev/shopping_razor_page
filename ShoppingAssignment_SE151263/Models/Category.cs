using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingAssignment_SE151263.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(15)]
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
