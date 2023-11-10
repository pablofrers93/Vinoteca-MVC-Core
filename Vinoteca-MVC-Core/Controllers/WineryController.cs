using Microsoft.AspNetCore.Mvc;
using Vinoteca_MVC_Core.Data;
using Vinoteca_MVC_Core.DataLayer.Repository.Interfaces;
using Vinoteca_MVC_Core.Models.Models;

namespace Vinoteca_MVC_Core.Controllers
{
    public class WineryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WineryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var wineryList = _unitOfWork.Wineries.GetAll();
            return View(wineryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Winery winery)
        {
            if (!ModelState.IsValid)
            {
                return View(winery);
            }
            if (_unitOfWork.Wineries.Exists(winery))
            {
                ModelState.AddModelError(string.Empty, "Winery already exists. Try another different.");
                return View(winery);
            }
            _unitOfWork.Wineries.Add(winery);
            _unitOfWork.Wineries.Save();
            TempData["success"] = "Record added successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var winery = _unitOfWork.Wineries.Get(v => v.Id == id);
            if (winery == null)
            {
                return NotFound();
            }

            return View(winery);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Winery winery)
        {
            if (!ModelState.IsValid)
            {
                return View(winery);
            }
            if (_unitOfWork.Wineries.Exists(winery))
            {
                ModelState.AddModelError(string.Empty, "Winery already exists. Try another different.");
                return View(winery);
            }
            _unitOfWork.Wineries.Update(winery);
            _unitOfWork.Wineries.Save();
            TempData["success"] = "Record updated successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var winery = _unitOfWork.Wineries.Get(v => v.Id == id);
            if (winery == null)
            {
                return NotFound();
            }

            return View(winery);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var winery = _unitOfWork.Wineries.Get(v => v.Id == id);
            if (winery == null)
            {
                ModelState.AddModelError(string.Empty, "Winery does not exist.");
            }
            _unitOfWork.Wineries.Delete(winery);
            _unitOfWork.Wineries.Save();
            TempData["success"] = "Record removed successfully";

            return RedirectToAction("Index");
        }
    }
}
