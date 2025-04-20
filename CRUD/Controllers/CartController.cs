using CRUD.Infrastructure;
using CRUD.Models;
using CRUD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;
        public CartController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVM);
        }
        public async Task<IActionResult> Add(long id)
        {
            Product product = await _context.Products.FindAsync(id);
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = cart.FirstOrDefault(x => x.ProductId == id);
            //CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();
            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity++;
            }
            HttpContext.Session.SetJson("Cart", cart);
            TempData["success"] = "Product added to cart successfully!";
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
