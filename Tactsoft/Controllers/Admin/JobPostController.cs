using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class JobPostController : Controller
    {
        private readonly IJobPostService _jobPostService;

        public JobPostController(IJobPostService jobPostService)
        {
            this._jobPostService = jobPostService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _jobPostService.GetAllAsync();
            return View(val);
        }

        // GET: JobCategoryController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var val = await _jobPostService.FindAsync(id);
            return View(val);
        }

        // GET: JobCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobPost jobPost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobPostService.InsertAsync(jobPost);
                }
                TempData["successAlert"] = "JobCategory  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobCategoryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var val = await _jobPostService.FindAsync(id);
            return View(val);
        }

        // POST: jobPostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobPost jobPost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobPostService.UpdateAsync(jobPost);
                }

                TempData["successAlert"] = "jobPost update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobCategoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var val = await _jobPostService.FindAsync(id);
            return View(val);
        }

        // POST: JobCategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _jobPostService.FindAsync(id);
                if (val != null)
                {
                    await _jobPostService.DeleteAsync(val);
                }
                TempData["successAlert"] = "JobCategory delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}