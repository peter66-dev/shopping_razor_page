﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.DataAccess;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.OrderDetails
{
    public class DetailsModel : PageModel
    {
        private readonly NorthwindCopyDBContext _context;

        public DetailsModel(NorthwindCopyDBContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
