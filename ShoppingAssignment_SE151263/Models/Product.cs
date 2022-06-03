using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingAssignment_SE151263.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public int? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }

        [StringLength(100)]
        public string? ProductImage { get; set; }
        public int? ProductStatus { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
