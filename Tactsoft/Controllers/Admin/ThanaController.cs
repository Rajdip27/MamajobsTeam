using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ThanaController : Controller
    {

        private readonly IThanaService _thanaService;
        private readonly IDistrictsService _districtsService;
        

        public ThanaController(IThanaService thanaService, IDistrictsService districtsService)
        {
            _thanaService = thanaService;
            this._districtsService = districtsService;
        }

        public async Task<IActionResult> Index()
        {

            var val = await _thanaService.GetAllAsync(i => i.District);
            return View(val);
        }


        public IActionResult Create()
        {
            ViewData["DistrictId"] = _districtsService.Dropdown();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Thana thana)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    await _thanaService.InsertAsync(thana);
                }
                TempData["successAlert"] = "Thana  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create", thana);
            }



        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _thanaService.FindAsync(id);
            if (val == null)
            {
                return NotFound();
            }

            ViewData["DistricId"] = _districtsService.Dropdown();
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Thana thana)
        {
            if (ModelState.IsValid)
            {


                await _thanaService.UpdateAsync(thana);
                TempData["successAlert"] = "thana update successfull.";

                return RedirectToAction(nameof(Index));

            }

            return View(thana);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dc = await _thanaService.FindAsync(m => m.Id == id, i => i.District);
            if (dc == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = _districtsService.Dropdown();


            return View(dc);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var dc = await _thanaService.FindAsync(id);
                if (dc != null)
                {
                    await _thanaService.DeleteAsync(dc);
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
            var val = await _thanaService.FindAsync(m => m.Id == id, i => i.District);
            return View(val);
        }




    }
}