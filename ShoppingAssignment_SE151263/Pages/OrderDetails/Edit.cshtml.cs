using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.Models;

namespace ShoppingAssignment_SE151263.Pages.OrderDetails
{
    public class EditModel : PageModel
    {
        private readonly ShoppingAssignment_SE151263.Models.ShoppingContext _context;

        public EditModel(ShoppingAssignment_SE151263.Models.ShoppingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product).FirstOrDefaultAsync(m => m.OrderID == id);

            if (OrderDetail == null)
            {
                return NotFound();
            }
           ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderID");
           ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(OrderDetail.OrderID))
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
            return _context.OrderDetails.Any(e => e.OrderID == id);
        }
    }
}
