using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.CustomerDetail
{

    public class CustomerDetailModel : PageModel
    {
        private readonly NorthwindCopyDBContext context;

        public CustomerDetailModel(NorthwindCopyDBContext _context)
        {
            context = _context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGet()
        {
            string customerID = HttpContext.Session.GetString("customerID");
            if (customerID == null)
            {
                ViewData["LoginMessage"] = "Bạn phải login trước khi xem thông tin cá nhân!";
                return Redirect("./Index"); // chưa trả về trang login được!
            }
            else
            {
                Customer = context.Customers.SingleOrDefault(c => c.CustomerId.Equals(customerID));
                System.Console.WriteLine("Customer name: " + Customer.ContactName);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerExists(string id)
        {
            return context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
