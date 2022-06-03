using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingAssignment_SE151263.DataAccess
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public int? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ProductImage { get; set; }
        public byte? ProductStatus { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
