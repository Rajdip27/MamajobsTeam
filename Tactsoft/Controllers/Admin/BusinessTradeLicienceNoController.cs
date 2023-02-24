using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class BusinessTradeLicienceNoController : Controller
    {

        private readonly IBusinessTradeLicienceNoService _businessTradeLicienceNoService;

        public BusinessTradeLicienceNoController(IBusinessTradeLicienceNoService businessTradeLicienceNoservice)
        {
            this._businessTradeLicienceNoService = businessTradeLicienceNoservice;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _businessTradeLicienceNoService.GetAllAsync();
            return View(val);
        }


        public async Task<IActionResult> Details(int id)
        {
            var val = await _businessTradeLicienceNoService.FindAsync(id);
            return View(val);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusinessTradeLicienceNo businessTradeLicienceNo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _businessTradeLicienceNoService.InsertAsync(businessTradeLicienceNo);
                }
                TempData["successAlert"] = "businessTradeLicienceNo  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _businessTradeLicienceNoService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BusinessTradeLicienceNo businessTradeLicienceNo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _businessTradeLicienceNoService.UpdateAsync(businessTradeLicienceNo);
                }

                TempData["successAlert"] = "businessTradeLicienceNo update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var val = await _businessTradeLicienceNoService.FindAsync(id);
            return View(val);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _businessTradeLicienceNoService.FindAsync(id);
                if (val != null)
                {
                    await _businessTradeLicienceNoService.DeleteAsync(val);
                }
                TempData["successAlert"] = "businessTradeLicienceNo delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}