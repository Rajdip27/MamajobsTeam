using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class EntrepreneurController : Controller
    {
        private readonly IEntrepreneurService _eyntrepreneurService;

        public EntrepreneurController(IEntrepreneurService entrepreneurService)
        {
            this._eyntrepreneurService = entrepreneurService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _eyntrepreneurService.GetAllAsync();
            return View(val);
        }


        public async Task<IActionResult> Details(int id)
        {
            var val = await _eyntrepreneurService.FindAsync(id);
            return View(val);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Entrepreneur eyntrepreneur)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _eyntrepreneurService.InsertAsync(eyntrepreneur);
                }
                TempData["successAlert"] = "eyntrepreneur  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _eyntrepreneurService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Entrepreneur eyntrepreneur)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _eyntrepreneurService.UpdateAsync(eyntrepreneur);
                }

                TempData["successAlert"] = "companyName update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var val = await _eyntrepreneurService.FindAsync(id);
            return View(val);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _eyntrepreneurService.FindAsync(id);
                if (val != null)
                {
                    await _eyntrepreneurService.DeleteAsync(val);
                }
                TempData["successAlert"] = "eyntrepreneur delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}