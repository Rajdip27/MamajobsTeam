using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class RLNOController : Controller
    {
        private readonly IRLNOService _rLNOService;

        public RLNOController(IRLNOService rLNOService)
        {
            this._rLNOService = rLNOService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _rLNOService.GetAllAsync();
            return View(val);
        }

     
        public async Task<IActionResult> Details(int id)
        {
            var val = await _rLNOService.FindAsync(id);
            return View(val);
        }

       
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RLNO rLNO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _rLNOService.InsertAsync(rLNO);
                }
                TempData["successAlert"] = "RLNO  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

 
        public async Task<IActionResult> Edit(int id)
        {
            var val = await _rLNOService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RLNO rLNO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _rLNOService.UpdateAsync(rLNO);
                }

                TempData["successAlert"] = "RLNO update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var val = await _rLNOService.FindAsync(id);
            return View(val);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _rLNOService.FindAsync(id);
                if (val != null)
                {
                    await _rLNOService.DeleteAsync(val);
                }
                TempData["successAlert"] = "RLNO delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}