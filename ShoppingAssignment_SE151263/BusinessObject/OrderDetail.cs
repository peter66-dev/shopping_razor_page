using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ShoppingAssignment_SE151263.DataAccess
{
    public partial class OrderDetail
    {
        public string OrderId { get; set; }

        [Display(Name ="Product name")]
        [Required(ErrorMessage ="Bạn phải chọn tên sản phẩm!")]
        public int ProductId { get; set; }

        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }

        [Display(Name ="Quantity buy")]
        [Required(ErrorMessage = "Số lượng mua không hợp lệ!")]
        [Range(1,1000)]
        public short Quantity { get; set; }

        [BindProperty]
        public virtual Order Order { get; set; }
        
        [BindProperty]
        public virtual Product Product { get; set; }
    }
}
