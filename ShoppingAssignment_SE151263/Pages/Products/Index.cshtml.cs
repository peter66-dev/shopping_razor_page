using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingAssignment_SE151263.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.Products
{
    public class IndexModel : PageModel
    {

        private readonly IConfiguration configuration;

        private readonly NorthwindCopyDBContext _context;

        public IndexModel(NorthwindCopyDBContext context, IConfiguration con)
        {
            _context = context;
            configuration = con;
        }

        //public IList<Product> Product { get;set; }
        public PaginatedList<Product> Products { get; set; }

        public string NameSort { get; set; }
        public string QuantitySort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //Product = await _context.Products
            //    .Include(p => p.Category)
            //    .Include(p => p.Supplier).ToListAsync();
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            QuantitySort = String.IsNullOrEmpty(sortOrder) ? "quantity_desc" : "";
            PriceSort = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            IQueryable<Product> productsIQ = from p in _context.Products
                                             select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                productsIQ = productsIQ.Where(p => p.ProductName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(sortOrder))
            {
                if (sortOrder.Equals("name_desc"))
                {
                    productsIQ = productsIQ.OrderByDescending(c => c.ProductName);
                }
                else if (sortOrder.Equals("quantity_desc"))
                {
                    productsIQ = productsIQ.OrderByDescending(c => c.QuantityPerUnit);
                }
                else if (sortOrder.Equals("price_desc"))
                {
                    productsIQ = productsIQ.OrderByDescending(c => c.UnitPrice);
                }
            }
            else
            {
                productsIQ = productsIQ.OrderByDescending(c => c.UnitPrice).Reverse();
            }


            var pageSize = configuration.GetValue("PageSize", 4);
            Products = await PaginatedList<Product>.CreateAsync(
                productsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
