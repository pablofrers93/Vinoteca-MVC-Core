using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Vinoteca_MVC_Core.Data;
using Vinoteca_MVC_Core.DataLayer.Repository.Interfaces;
using Vinoteca_MVC_Core.Models.Models;

namespace Vinoteca_MVC_Core.Controllers
{
	public class VarietyController : Controller
	{
		private readonly IVarietyRepository _varietyRepo;

        public VarietyController(IVarietyRepository varietyRepo)
        {
            _varietyRepo = varietyRepo;
        }

        public IActionResult Index()
		{
			var varietyList = _varietyRepo.GetAll();
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
			if (_varietyRepo.Exists(variety))
			{
				ModelState.AddModelError(string.Empty, "Variety already exists. Try another different.");
				return View(variety);
			}
			_varietyRepo.Add(variety);
            _varietyRepo.Save();
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
			var variety = _db.Varieties.FirstOrDefault(v => v.Id == id);
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
            if (_db.Varieties.Any(v => v.VarietyName == variety.VarietyName && v.Id != variety.Id))
            {
                ModelState.AddModelError(string.Empty, "Variety already exists. Try another different.");
                return View(variety);
            }
            _db.Varieties.Update(variety);
            _db.SaveChanges();
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
            var variety = _db.Varieties.FirstOrDefault(v => v.Id == id);
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
            var variety = _db.Varieties.FirstOrDefault(v => v.Id == id);
            if (variety == null)
            {
                ModelState.AddModelError(string.Empty, "Variety does not exist.");
            }
            _db.Varieties.Remove(variety);
            _db.SaveChanges();
            TempData["success"] = "Record removed successfully";

            return RedirectToAction("Index");
        }
    }
}
