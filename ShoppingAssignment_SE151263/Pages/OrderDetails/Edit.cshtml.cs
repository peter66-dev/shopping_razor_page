using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.OrderDetails
{
    public class EditModel : PageModel
    {
        private readonly NorthwindCopyDBContext _context;

        public EditModel(NorthwindCopyDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(string orderId, int productId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                return NotFound();
            }

            OrderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product).FirstOrDefaultAsync(m => m.OrderId.Trim().Equals(orderId.Trim()) && m.ProductId == productId);

            if (OrderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            if (!ModelState.IsValid)
            {
                return Page();
            }


            try
            {
                _context.Attach(OrderDetail).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(OrderDetail.OrderId))
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

        private bool OrderDetailExists(string id)
        {
            return _context.OrderDetails.Any(e => e.OrderId == id);
        }
    }
}
