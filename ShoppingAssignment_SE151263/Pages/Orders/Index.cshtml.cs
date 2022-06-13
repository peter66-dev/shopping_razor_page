using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingAssignment_SE151263.DataAccess;

namespace ShoppingAssignment_SE151263.Pages.Orders
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

        public PaginatedList<Order> Orders { get; set; }

        public string CustomerIDSort { get; set; }
        public string OrderDateSort { get; set; }
        public string FreightSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }


        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            CustomerIDSort = String.IsNullOrEmpty(sortOrder) ? "customerid_desc" : "";
            OrderDateSort = String.IsNullOrEmpty(sortOrder) ? "orderdate_desc" : "";
            OrderDateSort = String.IsNullOrEmpty(sortOrder) ? "freight_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            IQueryable<Order> ordersIQ = from o in _context.Orders
                                         select o;
            if (!String.IsNullOrEmpty(searchString))
            {
                ordersIQ = ordersIQ.Where(c => c.CustomerId.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(sortOrder))
            {
                if (sortOrder.Equals("customerid_desc"))
                {
                    ordersIQ = ordersIQ.OrderByDescending(o => o.CustomerId);
                }
                else if (sortOrder.Equals("orderdate_desc"))
                {
                    ordersIQ = ordersIQ.OrderByDescending(o => o.OrderDate);
                }
                else if (sortOrder.Equals("freight_desc"))
                {
                    ordersIQ = ordersIQ.OrderByDescending(o => o.Freight);
                }
                else
                {
                    ordersIQ = ordersIQ.OrderByDescending(o => o.CustomerId);
                }
            }
            else
            {
                ordersIQ = ordersIQ.OrderByDescending(o => o.CustomerId);
            }


            var pageSize = configuration.GetValue("PageSize", 4);
            Orders = await PaginatedList<Order>.CreateAsync(
                ordersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            if (Orders.Count != 0)
            {
                double total = 0;
                foreach (var o in Orders)
                {
                    total += (double)o.Freight.Value;
                    List<OrderDetail> list = _context.OrderDetails.Where(ord => ord.OrderId.Equals(o.OrderId)).ToList();
                    if (list.Count != 0)
                    {
                        foreach (var od in list)
                        {
                            total += (double)(od.Quantity * od.UnitPrice);
                        }
                    }
                }
                ViewData["total"] = Math.Round(total, 2);
            }
        }

        public IActionResult OnGetStatistic()
        {
            Console.WriteLine("Start date: " + StartDate);
            Console.WriteLine("End date: " + EndDate);
            return Page();
        }
    }
}
