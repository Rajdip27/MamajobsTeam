using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class DistrictController : Controller
    {
        private readonly IDistrictsService _districtsService;
        private readonly ICountryssService _countryssService;

        public DistrictController(IDistrictsService districtsService, ICountryssService countryssService)
        {
            _districtsService = districtsService;
            this._countryssService = countryssService;
        }

        public async Task<IActionResult> Index()
        {

            var val = await _districtsService.GetAllAsync(i => i.Countrys);
            return View(val);
        }


        public IActionResult Create()
        {
            ViewData["CountrysId"] = _countryssService.Dropdown();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(District district)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    await _districtsService.InsertAsync(district);
                }
                TempData["successAlert"] = "district  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create", district);
            }



        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _districtsService.FindAsync(id);
            if (val == null)
            {
                return NotFound();
            }

            ViewData["CountrysId"] = _countryssService.Dropdown();
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(District district)
        {
            if (ModelState.IsValid)
            {


                await _districtsService.UpdateAsync(district);
                TempData["successAlert"] = "district update successfull.";

                return RedirectToAction(nameof(Index));

            }

            return View(district);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dc = await _districtsService.FindAsync(m => m.Id == id, i => i.Countrys);
            if (dc == null)
            {
                return NotFound();
            }
            ViewData["CountrysId"] = _countryssService.Dropdown();


            return View(dc);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var dc = await _districtsService.FindAsync(id);
                if (dc != null)
                {
                    await _districtsService.DeleteAsync(dc);
                }
                TempData["successAlert"] = "district delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            var val = await _districtsService.FindAsync(m => m.Id == id, i => i.Countrys);
            return View(val);
        }




    }
}