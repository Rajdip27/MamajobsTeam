using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ResumeReceivingOptionController : Controller
    {
        private readonly IResumeReceivingOptionsService _resumeReceivingOptionsService;

        public ResumeReceivingOptionController(IResumeReceivingOptionsService resumeReceivingOptionsService)
        {
            this._resumeReceivingOptionsService = resumeReceivingOptionsService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _resumeReceivingOptionsService.GetAllAsync();
            return View(val);
        }

        // GET: ResumeReceivingOptionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var val = await _resumeReceivingOptionsService.FindAsync(id);
            return View(val);
        }

        // GET: ResumeReceivingOptionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResumeReceivingOptionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResumeReceivingOption resumeReceivingOption)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _resumeReceivingOptionsService.InsertAsync(resumeReceivingOption);
                }
                TempData["successAlert"] = "resumeReceivingOption  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResumeReceivingOptionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var val = await _resumeReceivingOptionsService.FindAsync(id);
            return View(val);
        }

        // POST: ResumeReceivingOptionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ResumeReceivingOption resumeReceivingOption)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _resumeReceivingOptionsService.UpdateAsync(resumeReceivingOption);
                }

                TempData["successAlert"] = "resumeReceivingOption update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResumeReceivingOptionController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var val = await _resumeReceivingOptionsService.FindAsync(id);
            return View(val);
        }

        // POST: ResumeReceivingOptionController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _resumeReceivingOptionsService.FindAsync(id);
                if (val != null)
                {
                    await _resumeReceivingOptionsService.DeleteAsync(val);
                }
                TempData["successAlert"] = "resumeReceivingOption delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}