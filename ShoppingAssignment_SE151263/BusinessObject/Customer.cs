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
        [Required(ErrorMessage = "Password phải từ 1-20 kí tự!")]
        [MaxLength(20), MinLength(1)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Không được để trống tên!")]
        [Display(Name ="Name")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Không được để trống địa chỉ!")]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Không được để trống Email!")]
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
