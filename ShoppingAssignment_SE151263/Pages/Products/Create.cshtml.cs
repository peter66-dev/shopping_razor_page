using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingAssignment_SE151263.DataAccess;
using ShoppingAssignment_SE151263.Repository;
using System;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly NorthwindCopyDBContext _context;
        private IProductRepository proRepo;

        public CreateModel(NorthwindCopyDBContext context)
        {
            _context = context;
            proRepo = new ProductRepository();
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
                bool isDuplicatedName = proRepo.CheckNameExist(Product.ProductName);
                bool isDuplicatedImage = proRepo.CheckImageExist(Product.ProductImage);

                if (isDuplicatedName)
                {
                    ViewData["ProductNameMessage"] = "Tên sản phẩm này đã tồn tại!";
                    Console.WriteLine("Tên sản phẩm này đã tồn tại!");
                }

                if (isDuplicatedImage)
                {
                    ViewData["ImageMessage"] = "Đường dẫn này đã tồn tại!";
                    Console.WriteLine("Đường dẫn này đã tồn tại!");
                }

                if (!isDuplicatedName && !isDuplicatedImage)
                {
                    Product.ProductName = Product.ProductName.Trim();
                    Product.ProductImage = Product.ProductImage.Trim();
                    _context.Products.Add(Product);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ViewData["IDErrorMessage"] = "Error msg: " + ex.Message;
                return Page();
            }

        }
    }
}
