using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.DataAccess;

namespace ShoppingAssignment_SE151263.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingAssignment_SE151263.DataAccess.NorthwindCopyDBContext _context;

        public IndexModel(ShoppingAssignment_SE151263.DataAccess.NorthwindCopyDBContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToListAsync();
        }
    }
}
