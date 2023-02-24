using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class JobLevelController : Controller
    {
        private readonly IJobLevelService _jobLevelService;


        public JobLevelController(IJobLevelService jobLevelService)
        {
            this._jobLevelService = jobLevelService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _jobLevelService.GetAllAsync();
            return View(val);
        }


        public async Task<IActionResult> Details(int id)
        {
            var val = await _jobLevelService.FindAsync(id);
            return View(val);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobLevel jobLevel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobLevelService.InsertAsync(jobLevel);
                }
                TempData["successAlert"] = "_jobLevel  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _jobLevelService.FindAsync(id);
            return View(val);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobLevel jobLevel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobLevelService.UpdateAsync(jobLevel);
                }

                TempData["successAlert"] = "jobLevel update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var val = await _jobLevelService.FindAsync(id);
            return View(val);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _jobLevelService.FindAsync(id);
                if (val != null)
                {
                    await _jobLevelService.DeleteAsync(val);
                }
                TempData["successAlert"] = "jobLevel delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}