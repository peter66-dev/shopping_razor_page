using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.Models;

namespace ShoppingAssignment_SE151263.Pages.Suppliers
{
    public class DetailsModel : PageModel
    {
        private readonly ShoppingAssignment_SE151263.Models.ShoppingContext _context;

        public DetailsModel(ShoppingAssignment_SE151263.Models.ShoppingContext context)
        {
            _context = context;
        }

        public Supplier Supplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplier = await _context.Suppliers.FirstOrDefaultAsync(m => m.SupplierID == id);

            if (Supplier == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
