using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ShoppingAssignment_SE151263.BusinessObject;
using ShoppingAssignment_SE151263.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShoppingAssignment_SE151263.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Account Account { get; set; }

        NorthwindCopyDBContext context;


        public LoginModel(NorthwindCopyDBContext c)
        {
            context = c;
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            Console.WriteLine("[System message]: Logout!");
            return Page();
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("Email: " + Account.Email);
            Console.WriteLine("Password: " + Account.Password);
            Account admin = GetAccountAdmin();
            if (admin.Email.Equals(Account.Email) && admin.Password.Equals(Account.Password))
            {
                Console.WriteLine("Toi la admin!");
                HttpContext.Session.SetString("EmailAdmin", admin.Email);
                return new RedirectResult("./Customers/Index");
            }
            else
            {
                List<Customer> list = context.Customers.ToList();
                foreach (var tmp in list)
                {
                    if (tmp.Email.Equals(Account.Email) && tmp.Password.Equals(Account.Password))
                    {
                        Console.WriteLine("Toi la customer!");
                        HttpContext.Session.SetString("customerID", tmp.CustomerId);
                        HttpContext.Session.SetString("customerName", tmp.ContactName);
                        return new RedirectToPageResult("./CustomerDetail/CustomerDetail");
                    }
                }
            }
            ViewData["LoginMessage"] = "Email and Password is not valid!";
            return Page();
        }

        private Account GetAccountAdmin()
        {
            Account acc = null;
            using (StreamReader r = new StreamReader("appsettings.json"))
            {
                string json = r.ReadToEnd();
                IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
                string email = config["Account:Email"];
                string password = config["Account:Password"];
                acc = new Account();
                acc.Email = email;
                acc.Password = password;
            }
            return acc;
        }
    }
}
