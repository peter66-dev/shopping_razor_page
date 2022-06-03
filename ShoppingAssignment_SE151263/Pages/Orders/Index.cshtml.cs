using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.DataAccess;

namespace ShoppingAssignment_SE151263.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly ShoppingAssignment_SE151263.DataAccess.NorthwindCopyDBContext _context;

        public IndexModel(ShoppingAssignment_SE151263.DataAccess.NorthwindCopyDBContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Customer).ToListAsync();
        }
    }
}
