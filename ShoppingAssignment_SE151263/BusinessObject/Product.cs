using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name ="Name")]
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        
        [Display(Name = "Quantity")]
        public int? QuantityPerUnit { get; set; }

        [Display(Name ="Price")]
        public decimal? UnitPrice { get; set; }

        [Display(Name ="Image")]
        public string ProductImage { get; set; }

        [Display(Name ="Status")]
        
        public byte? ProductStatus { get; set; }

        [BindProperty]
        public virtual Category Category { get; set; }

        [BindProperty]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
