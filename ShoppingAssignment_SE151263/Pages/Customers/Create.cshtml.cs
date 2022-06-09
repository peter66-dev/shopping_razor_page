using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingAssignment_SE151263.DataAccess;

namespace ShoppingAssignment_SE151263.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ShoppingAssignment_SE151263.DataAccess.NorthwindCopyDBContext _context;

        public CreateModel(ShoppingAssignment_SE151263.DataAccess.NorthwindCopyDBContext context)
        {
            _context = context;
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
                _context.Customers.Add(Customer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "Lỗi: " + ex.Message;
                return RedirectToPage("./Privacy");
            }
        }
    }
}
