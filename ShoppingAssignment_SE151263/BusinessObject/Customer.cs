using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ShoppingAssignment_SE151263.DataAccess
{
    public partial class Customer
    {
        [Display(Name ="ID")]
        public string CustomerId { get; set; }

        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Mật khẩu phải từ 1-20 kí tự!")]
        [MaxLength(20), MinLength(1)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống!")]
        [Display(Name ="Name")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Không được để trống địa chỉ!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn cần cung cấp số điện thoại")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Email không được để trống!")]
        [EmailAddress]
        [Display(Name ="Customer email")]
        public string Email { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
    }
}
