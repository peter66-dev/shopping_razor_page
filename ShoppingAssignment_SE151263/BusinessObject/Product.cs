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
        [Required(ErrorMessage ="Bạn phải điền tên cho sản phẩm!")]
        public string ProductName { get; set; }
        
        [Display(Name = "Supplier name")]
        public int? SupplierId { get; set; }

        [Display(Name ="Category name")]
        public int? CategoryId { get; set; }
        
        [Display(Name = "Quantity")]
        [Range(1, 10000)]
        [Required(ErrorMessage ="Số lượng phải là số nguyên lớn hơn 0!")]
        public int? QuantityPerUnit { get; set; }

        [Display(Name ="Price")]
        [Range(1000, 1000000000)]
        [Required(ErrorMessage ="Giá tiền cho sản phẩm phải hợp lý!")]
        public decimal? UnitPrice { get; set; }

        [Display(Name ="Image link")]
        [Required(ErrorMessage ="Bạn phải điền URL hình ảnh cho sản phẩm!")]
        public string ProductImage { get; set; }

        [Display(Name ="Status")]
        [Range(0, 1)]
        public byte? ProductStatus { get; set; }

        [BindProperty]
        public virtual Category Category { get; set; }

        [BindProperty]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
