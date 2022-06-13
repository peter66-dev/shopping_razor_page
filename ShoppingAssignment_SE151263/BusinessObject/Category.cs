using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ShoppingAssignment_SE151263.DataAccess
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Display(Name ="ID")]
        public int CategoryId { get; set; }

        [BindProperty]
        [Display(Name = "Category name")]
        [Required(ErrorMessage = "Bạn phải nhập Category name!")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Description")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
