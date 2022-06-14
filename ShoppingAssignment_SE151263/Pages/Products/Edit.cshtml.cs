using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.DataAccess;
using ShoppingAssignment_SE151263.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly NorthwindCopyDBContext _context;
        private IProductRepository proRepo;

        public EditModel(NorthwindCopyDBContext context)
        {
            _context = context;
            proRepo = new ProductRepository();
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                bool isDuplicatedName = proRepo.CheckNameExist(Product.ProductId, Product.ProductName);
                bool isDuplicatedImage = proRepo.CheckImageExist(Product.ProductId, Product.ProductImage);

                if (isDuplicatedName)
                {
                    ViewData["NameMessage"] = $"Product name {Product.ProductName} đã tồn tại!";
                }
                if (isDuplicatedImage)
                {
                    ViewData["ImageMessage"] = $"Image link {Product.ProductImage} đã tồn tại!";
                }

                if (!isDuplicatedName && !isDuplicatedImage)
                {
                    Product.ProductName = Product.ProductName.Trim();
                    Product.ProductImage = Product.ProductImage.Trim();
                    _context.Attach(Product).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                else
                {
                    return Page();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    return Page();
                    throw;
                }
            }

        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
