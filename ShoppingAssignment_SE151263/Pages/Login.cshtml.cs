using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingAssignment_SE151263.BusinessObject;
using ShoppingAssignment_SE151263.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ShoppingAssignment_SE151263.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required field!")]
        [EmailAddress]
        public string EmailLogin { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required field!")]
        [DataType(DataType.Password)]
        public string PasswordLogin { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            Console.WriteLine("Email: " + EmailLogin);
            Console.WriteLine("Password: " + PasswordLogin);

        }

        private string CheckLogin()
        {
            string role = "Undefined";
            Account login = new Account();
           
            return role;
        }
    }
}
