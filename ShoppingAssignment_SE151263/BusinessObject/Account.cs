using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShoppingAssignment_SE151263.BusinessObject
{
    public class Account
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required field!")]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required field!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
