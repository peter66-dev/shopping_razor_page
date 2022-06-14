using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingAssignment_SE151263.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.CustomerDetail
{
    public class OrderHistoryModel : PageModel
    {
        private readonly NorthwindCopyDBContext _context;

        private readonly IConfiguration configuration;

        public OrderHistoryModel(NorthwindCopyDBContext context, IConfiguration con)
        {
            _context = context;
            configuration = con;
        }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Order> Orders { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, int? pageIndex)
        {
            Console.WriteLine("Toi la OnGetAsync method trong OrderHistoryModel!");
            string customerID = HttpContext.Session.GetString("customerID");
            if (customerID != null)
            {
                CurrentSort = sortOrder;
                DateSort = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

                CurrentFilter = currentFilter;
                IQueryable<Order> ordersIQ = from o in _context.Orders
                                             where o.CustomerId.Equals(customerID)
                                             select o;

                if (!String.IsNullOrEmpty(sortOrder))
                {
                    ordersIQ = ordersIQ.OrderByDescending(c => c.OrderDate);
                }
                else
                {
                    ordersIQ = ordersIQ.OrderByDescending(c => c.OrderDate).Reverse();
                }


                var pageSize = configuration.GetValue("PageSize", 4);
                Orders = await PaginatedList<Order>.CreateAsync(
                    ordersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
                Console.WriteLine($"Co {Orders.Count} hoa don!");
            }
            else
            {
                ViewData["LoginMessage"] = "Bạn không có quyền truy cập vào trang của Customer!";
                RedirectToPage("../Login");
            }

        }
    }
}
