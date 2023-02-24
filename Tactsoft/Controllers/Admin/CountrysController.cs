using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class CountrysController : Controller
    {
        private readonly ICountryssService _countryssService;

        public CountrysController(ICountryssService countryssService)
        {
            this._countryssService = countryssService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _countryssService.GetAllAsync();
            return View(val);
        }

    
        public async Task<IActionResult> Details(int id)
        {
            var val = await _countryssService.FindAsync(id);
            return View(val);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Countrys countrys)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _countryssService.InsertAsync(countrys);
                }
                TempData["successAlert"] = "Countrys  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var val = await _countryssService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Countrys countrys)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _countryssService.UpdateAsync(countrys);
                }

                TempData["successAlert"] = "countrys update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var val = await _countryssService.FindAsync(id);
            return View(val);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _countryssService.FindAsync(id);
                if (val != null)
                {
                    await _countryssService.DeleteAsync(val);
                }
                TempData["successAlert"] = "countrys delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}