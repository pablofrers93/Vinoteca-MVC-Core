using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Vinoteca_MVC_Core.Data;
using Vinoteca_MVC_Core.DataLayer.Repository.Interfaces;
using Vinoteca_MVC_Core.Models.Models;

namespace Vinoteca_MVC_Core.Controllers
{
    public class VarietyController : Controller
    {
        private readonly IUnitOfWork  _unitOfWork;

        public VarietyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
		{
			var varietyList = _unitOfWork.Varieties.GetAll();
			return View(varietyList);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Variety variety)
		{
			if (!ModelState.IsValid)
			{
				return View(variety); 
			}
			if (_unitOfWork.Varieties.Exists(variety))
			{
				ModelState.AddModelError(string.Empty, "Variety already exists. Try another different.");
				return View(variety);
			}
            _unitOfWork.Varieties.Add(variety);
            _unitOfWork.Varieties.Save();
            TempData["success"]="Record added successfully";
			return RedirectToAction("Index");	
		}
        [HttpGet]
        public IActionResult Edit(int? id)
        {
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var variety = _unitOfWork.Varieties.Get(v=> v.Id == id);
			if (variety == null)
			{
				return NotFound();
			}

            return View(variety);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Variety variety)
        {
            if (!ModelState.IsValid)
            {
                return View(variety);
            }
            if (_unitOfWork.Varieties.Exists(variety))
            {
                ModelState.AddModelError(string.Empty, "Variety already exists. Try another different.");
                return View(variety);
            }
            _unitOfWork.Varieties.Update(variety);
            _unitOfWork.Varieties.Save();
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
            var variety = _unitOfWork.Varieties.Get(v => v.Id == id);
            if (variety == null)
            {
                return NotFound();
            }

            return View(variety);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var variety = _unitOfWork.Varieties.Get(v => v.Id == id);
            if (variety == null)
            {
                ModelState.AddModelError(string.Empty, "Variety does not exist.");
            }
            _unitOfWork.Varieties.Delete(variety);
            _unitOfWork.Varieties.Save();
            TempData["success"] = "Record removed successfully";

            return RedirectToAction("Index");
        }
    }
}
