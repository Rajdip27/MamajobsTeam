using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class BusinessDescriptionController : Controller
    {

        private readonly IBusinessDescriptionService _businessDescriptionService;

        public BusinessDescriptionController(IBusinessDescriptionService businessDescriptionService)
        {
            this._businessDescriptionService = businessDescriptionService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _businessDescriptionService.GetAllAsync();
            return View(val);
        }


        public async Task<IActionResult> Details(int id)
        {
            var val = await _businessDescriptionService.FindAsync(id);
            return View(val);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusinessDescription businessDescription)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _businessDescriptionService.InsertAsync(businessDescription);
                }
                TempData["successAlert"] = "businessDescription  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _businessDescriptionService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BusinessDescription businessDescription)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _businessDescriptionService.UpdateAsync(businessDescription);
                }

                TempData["successAlert"] = "businessDescription update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var val = await _businessDescriptionService.FindAsync(id);
            return View(val);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _businessDescriptionService.FindAsync(id);
                if (val != null)
                {
                    await _businessDescriptionService.DeleteAsync(val);
                }
                TempData["successAlert"] = "businessDescription delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}