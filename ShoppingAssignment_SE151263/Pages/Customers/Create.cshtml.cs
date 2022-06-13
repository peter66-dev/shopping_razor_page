using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingAssignment_SE151263.DataAccess;
using ShoppingAssignment_SE151263.Repository;

namespace ShoppingAssignment_SE151263.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ShoppingAssignment_SE151263.DataAccess.NorthwindCopyDBContext _context;

        private ICustomerRepository customerRepo;

        public CreateModel(ShoppingAssignment_SE151263.DataAccess.NorthwindCopyDBContext context)
        {
            _context = context;
            customerRepo = new CustomerRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
                if (isDuplicatedID) // ID trong database cô gửi có quá nhiều dấu cách ạ!
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
                    int tmp = await _context.SaveChangesAsync();
                    if (tmp > 0)
                    {
                        ViewData["IndexMessage"] = "Tạo mới thành công!";
                    }
                    else
                    {
                        ViewData["IndexMessage"] = "Tạo mới thất bại!";
                    }
                    return RedirectToPage("./Index");
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
