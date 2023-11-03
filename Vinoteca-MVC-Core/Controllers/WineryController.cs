using Microsoft.AspNetCore.Mvc;
using Vinoteca_MVC_Core.Data;

namespace Vinoteca_MVC_Core.Controllers
{
    public class WineryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public WineryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var wineryList = _db.Wineries.ToList();
            return View(wineryList);
        }
    }
}
