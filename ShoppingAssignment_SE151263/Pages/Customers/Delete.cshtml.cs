using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.DataAccess;
using ShoppingAssignment_SE151263.Repository;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly NorthwindCopyDBContext _context;
        private ICustomerRepository cusRepo;

        public DeleteModel(NorthwindCopyDBContext context)
        {
            _context = context;
            cusRepo = new CustomerRepository();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (Customer != null)
            {
                if (cusRepo.DeleteCustomer(id))
                {
                    ViewData["Message"] = "Delete failed!";
                    return RedirectToPage("./Index");
                }
            }

            Customer = cusRepo.GetCustomerByID(id); ;
            return Page();
        }
    }
}
