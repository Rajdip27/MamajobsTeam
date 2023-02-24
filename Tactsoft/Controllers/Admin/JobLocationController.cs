using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class JobLocationController : Controller
    {
        private readonly IJobLocationService _jobLocationService;

        public JobLocationController(IJobLocationService jobLocationService)
        {
            this._jobLocationService = jobLocationService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _jobLocationService.GetAllAsync();
            return View(val);
        }

        // GET: JobLocationController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var val = await _jobLocationService.FindAsync(id);
            return View(val);
        }

        // GET: JobLocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobLocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobLocation jobLocation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobLocationService.InsertAsync(jobLocation);
                }
                TempData["successAlert"] = "jobLocation  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobLocationController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var val = await _jobLocationService.FindAsync(id);
            return View(val);
        }

        // POST: JobLocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobLocation jobLocation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobLocationService.UpdateAsync(jobLocation);
                }

                TempData["successAlert"] = "jobLocation update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobLocationController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var val = await _jobLocationService.FindAsync(id);
            return View(val);
        }

        // POST: JobLocationController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _jobLocationService.FindAsync(id);
                if (val != null)
                {
                    await _jobLocationService.DeleteAsync(val);
                }
                TempData["successAlert"] = "jobLocation delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}