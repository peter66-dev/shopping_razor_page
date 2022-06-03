using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.Models;

namespace ShoppingAssignment_SE151263.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly ShoppingAssignment_SE151263.Models.ShoppingContext _context;

        public DetailsModel(ShoppingAssignment_SE151263.Models.ShoppingContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
