using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingAssignment_SE151263.DataAccess;
using ShoppingAssignment_SE151263.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly NorthwindCopyDBContext _context;

        private ICustomerRepository customerRepo;
        [BindProperty]
        public Customer Customer { get; set; }

        public RegisterModel(NorthwindCopyDBContext context)
        {
            _context = context;
            customerRepo = new CustomerRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                List<Customer> list = _context.Customers.ToList();
                bool isDuplicatedID = customerRepo.CheckIDExist(Customer.CustomerId.Trim());
                bool isDuplicatedEmail = customerRepo.CheckEmailExist(Customer.Email.Trim());
                if (isDuplicatedID) 
                {
                    ViewData["IDErrorMessage"] = $"ID {Customer.CustomerId} đã tồn tại!";
                    Console.WriteLine("Duplicated ID! ID: " + Customer.CustomerId);
                }
                if (isDuplicatedEmail)
                {
                    ViewData["EmailErrorMessage"] = $"Email {Customer.Email} đã tồn tại!";
                    Console.WriteLine("Duplicated Email! Email: " + Customer.Email);
                }

                if (!isDuplicatedEmail && !isDuplicatedID)
                {
                    Customer.CustomerId = Customer.CustomerId.Trim();
                    Customer.Email = Customer.Email.Trim();
                    _context.Customers.Add(Customer);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Login");
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ViewData["IDErrorMessage"] = "Error msg: " + ex.Message;
                return Page();
            }
        }
    }
}
