using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingAssignment_SE151263.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.OrderDetails
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindCopyDBContext _context;

        private readonly IConfiguration configuration;

        public IndexModel(NorthwindCopyDBContext context, IConfiguration con)
        {
            _context = context;
            configuration = con;
        }
        public string QuantitySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<OrderDetail> OrderDetails { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            QuantitySort = String.IsNullOrEmpty(sortOrder) ? "quantity_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            IQueryable<OrderDetail> orderDetailsIQ = from od in _context.OrderDetails
                                                     select od;
            if (!String.IsNullOrEmpty(searchString))
            {
                orderDetailsIQ = orderDetailsIQ.Where(c => c.OrderId.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(sortOrder))
            {
                orderDetailsIQ = orderDetailsIQ.OrderByDescending(o => o.Quantity);
            }
            else
            {
                orderDetailsIQ = orderDetailsIQ.OrderByDescending(o => o.Quantity).Reverse();
            }


            var pageSize = configuration.GetValue("PageSize", 4);
            OrderDetails = await PaginatedList<OrderDetail>.CreateAsync(
                orderDetailsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
