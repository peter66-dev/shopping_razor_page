using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingAssignment_SE151263.DataAccess;
using ShoppingAssignment_SE151263.Repository;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindCopyDBContext _context;

        private IOrderRepository orderRepo;

        private readonly IConfiguration configuration;
        public IndexModel(NorthwindCopyDBContext context, IConfiguration con)
        {
            _context = context;
            configuration = con;
            orderRepo = new OrderRepository();
        }

        public PaginatedList<Order> Orders { get; set; }

        public string IDSort { get; set; }
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
            //StartDate = DateTime.Now;
            //EndDate = DateTime.Now;
            CurrentSort = sortOrder;
            IDSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            OrderDateSort = String.IsNullOrEmpty(sortOrder) ? "orderdate_desc" : "";
            FreightSort = String.IsNullOrEmpty(sortOrder) ? "freight_desc" : "";

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

            double total = 0;
            if (!String.IsNullOrEmpty(searchString))
            {
                total = orderRepo.GetTotal(_context.Orders.Where(o => o.CustomerId.Trim().Contains(searchString.Trim())).ToList());
                ordersIQ = ordersIQ.Where(c => c.CustomerId.Contains(searchString));
            }
            else
            {
                total = orderRepo.GetTotal(_context.Orders.ToList());
            }
            var info = CultureInfo.GetCultureInfo("vi-VN");
            ViewData["total"] = String.Format(info, "{0:c}", total);

            if (!String.IsNullOrEmpty(sortOrder))
            {
                if (sortOrder.Equals("id_desc"))
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
            }
            else
            {
                ordersIQ = ordersIQ.OrderByDescending(o => o.CustomerId).Reverse();
            }


            var pageSize = configuration.GetValue("PageSize", 4);
            Orders = await PaginatedList<Order>.CreateAsync(
                ordersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            //if (Orders.Count != 0)
            //{
            //    double total = orderRepo.GetTotal(this.Orders);
            //    ViewData["total"] = Math.Round(total, 2);
            //}
        }

        public IActionResult OnGetStatistic()
        {
            Console.WriteLine("Start date: " + StartDate);
            Console.WriteLine("End date: " + EndDate);
            return Page();
        }
    }
}
