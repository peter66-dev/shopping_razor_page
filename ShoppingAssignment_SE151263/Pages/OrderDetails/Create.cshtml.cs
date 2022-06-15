using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingAssignment_SE151263.DataAccess;
using ShoppingAssignment_SE151263.Repository;
using System;
using System.Threading.Tasks;

namespace ShoppingAssignment_SE151263.Pages.OrderDetails
{
    public class CreateModel : PageModel
    {
        private readonly ShoppingAssignment_SE151263.DataAccess.NorthwindCopyDBContext _context;
        private IOrderDetailRepository odRepo;
        private IProductRepository proRepo;

        public CreateModel(ShoppingAssignment_SE151263.DataAccess.NorthwindCopyDBContext context)
        {
            _context = context;
            odRepo = new OrderDetailRepository();
            proRepo = new ProductRepository();
        }

        public IActionResult OnGet()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (odRepo.CheckExist(OrderDetail.OrderId, OrderDetail.ProductId))
                {
                    ViewData["OrderDetailMessage"] = "Đơn hàng này đã tồn tại, bạn có thể vào trang edit!";
                    return Page();
                }
                else
                {
                    if (proRepo.CheckQuantity(OrderDetail.ProductId, OrderDetail.Quantity)
                        && proRepo.SubQuantity(OrderDetail.ProductId, OrderDetail.Quantity))
                    {
                        Product currentPro = proRepo.GetProductByID(OrderDetail.ProductId);
                        OrderDetail.UnitPrice = currentPro.UnitPrice.Value;
                        _context.OrderDetails.Add(OrderDetail);
                        await _context.SaveChangesAsync();
                        return RedirectToPage("./Index");
                    }
                    else
                    {
                        ViewData["OrderDetailMessage"] = "Xin lỗi, chúng tôi không đủ số lượng cho sản phẩm này!";
                        return Page();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at Task<IActionResult> OnPostAsync: " + ex.Message);
                return Page();
            }
        }
    }
}
