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
    public class OrderDetailCustomer : PageModel
    {
        private readonly NorthwindCopyDBContext _context;

        private readonly IConfiguration configuration;

        public OrderDetailCustomer(NorthwindCopyDBContext context, IConfiguration con)
        {
            _context = context;
            configuration = con;
        }
        public string DateSort { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentSort { get; set; }

        public PaginatedList<OrderDetail> OrderDetails { get; set; }

        public async Task OnGetAsync(string id, string sortOrder, string currentFilter, int? pageIndex)
        {
            Console.WriteLine("Toi la OnGetAsync method trong OrderDetailCustomer!");
            string customerID = HttpContext.Session.GetString("customerID");
            if (customerID != null)
            {
                CurrentSort = sortOrder;
                DateSort = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

                CurrentFilter = currentFilter;
                IQueryable<OrderDetail> ordersDetailIQ = from o in _context.OrderDetails
                                                         where o.OrderId.Equals(id)
                                                         select o;

                if (!String.IsNullOrEmpty(sortOrder))
                {
                    ordersDetailIQ = ordersDetailIQ.OrderByDescending(c => c.Order.OrderDate);
                }
                else
                {
                    ordersDetailIQ = ordersDetailIQ.OrderByDescending(c => c.Order.OrderDate).Reverse();
                }


                var pageSize = configuration.GetValue("PageSize", 10);
                OrderDetails = await PaginatedList<OrderDetail>.CreateAsync(
                    ordersDetailIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
                Console.WriteLine($"Co {OrderDetails.Count} hoa don!");
            }
            else
            {
                ViewData["LoginMessage"] = "Bạn không có quyền truy cập vào trang của Customer!";
                RedirectToPage("../Login");
            }

        }

    }
}
