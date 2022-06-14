using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ShoppingAssignment_SE151263.DataAccess
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Display(Name ="ID")]
        [Required(ErrorMessage ="Bạn phải nhập ID!")]
        public string OrderId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập CustomerID!")]
        [Display(Name = "CustomerID")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập chuẩn mẫu date ngày-tháng-năm!")]
        [Display(Name = "OrderDate")]
        
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Required Date")]
        [Required(ErrorMessage = "Bạn phải nhập chuẩn mẫu date ngày-tháng-năm!")]
        public DateTime? RequiredDate { get; set; }

        [Display(Name = "Shipped Date")]
        [Required(ErrorMessage = "Bạn phải nhập chuẩn mẫu date ngày-tháng-năm!")]
        public DateTime? ShippedDate { get; set; }

        [Range(10000, 1000000)]
        [Required(ErrorMessage = "Bạn phải nhập phí chuyển tiền!")]
        [Display(Name ="Ship money")]
        public decimal? Freight { get; set; }

        [Display(Name = "Ship Address")]
        [Required(ErrorMessage = "Bạn phải nhập ShipAddress!")]
        public string ShipAddress { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
