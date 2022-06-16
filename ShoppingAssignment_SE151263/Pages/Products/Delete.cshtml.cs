using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.DataAccess;
using ShoppingAssignment_SE151263.Repository;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly NorthwindCopyDBContext _context;
        private IProductRepository proRepo;

        public DeleteModel(NorthwindCopyDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                if (proRepo.DeleteProduct(id.Value))
                {
                    System.Console.WriteLine("Delete PRODUCT thanh cong!");
                    return RedirectToPage("./Index");
                }
                else
                {
                    ViewData["Message"] = "Xoá thất bại vì sản phẩm này đang có thông tin bên bảng order detail!";
                    Product = await _context.Products
                                        .Include(p => p.Category)
                                        .Include(p => p.Supplier).FirstOrDefaultAsync(m => m.ProductId == id);
                    return Page();
                }
            }
        }
    }
}
