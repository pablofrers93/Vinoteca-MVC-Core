using Microsoft.AspNetCore.Mvc;
using Vinoteca_MVC_Core.Data;

namespace Vinoteca_MVC_Core.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var productList = _db.Products.ToList();
            return View(productList);
        }
        public IActionResult Offers()
        {
            var productList = _db.Products.ToList();
            return View(productList);
        }
    }
}
