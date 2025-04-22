using CRUD.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Areas.Controllers
{
    public class ProductsController : Controller
    {
        [Area("Admin")]
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
