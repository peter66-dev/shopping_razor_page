using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingAssignment_SE151263.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.Customers
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

        public string NameSort { get; set; }
        public string EmailSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Customer> Customers { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //Customer = await _context.Customers.ToListAsync();
            Console.WriteLine("Toi la OnGetAsync method!");
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            EmailSort = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            IQueryable<Customer> customersIQ = from c in _context.Customers
                                               select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                customersIQ = customersIQ.Where(c => c.ContactName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(sortOrder))
            {
                if (sortOrder.Equals("email_desc"))
                {
                    customersIQ = customersIQ.OrderByDescending(c => c.Email);
                }
                else
                {
                    customersIQ = customersIQ.OrderByDescending(c => c.Email);
                }
            }
            else
            {
                customersIQ = customersIQ.OrderByDescending(c => c.Email);
            }


            var pageSize = configuration.GetValue("PageSize", 4);
            Customers = await PaginatedList<Customer>.CreateAsync(
                customersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
