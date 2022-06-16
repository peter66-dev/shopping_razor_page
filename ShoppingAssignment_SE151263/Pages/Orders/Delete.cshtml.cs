using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.DataAccess;
using ShoppingAssignment_SE151263.Repository;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly NorthwindCopyDBContext _context;
        private IOrderRepository repo;

        public DeleteModel(NorthwindCopyDBContext context)
        {
            _context = context;
            repo = new OrderRepository();
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.Customer).FirstOrDefaultAsync(m => m.OrderId == id);

            if (Order == null)
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

            repo.DeleteOrder(id); // Xoá ngay cả order detail

            return RedirectToPage("./Index");
        }
    }
}
