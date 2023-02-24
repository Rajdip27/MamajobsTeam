using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class JobSubCatagoryController : Controller
    {
        private readonly IJobSubCategoryService _jobSubCategoryService;
        private readonly IJobCategoryService _jobCategoryService;

        public JobSubCatagoryController(IJobSubCategoryService jobSubCategoryService, IJobCategoryService jobCategoryService)
        {
            _jobSubCategoryService = jobSubCategoryService;
            this._jobCategoryService = jobCategoryService;
        }

        public async Task<IActionResult> Index()
        {

            var val = await _jobSubCategoryService.GetAllAsync(i => i.JobCategory);
            return View(val);
        }


        public IActionResult Create()
        {
            ViewData["JobCategoryId"] = _jobCategoryService.Dropdown();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobSubCategory jobSubCategory)
        {
           
             
            try
            {
                if (ModelState.IsValid)
                {
                    await _jobSubCategoryService.InsertAsync(jobSubCategory);
                }
                TempData["successAlert"] = "jobSubCategoryService  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create", jobSubCategory);
            }



        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _jobSubCategoryService.FindAsync(id);
            if (val == null)
            {
                return NotFound();
            }

            ViewData["JobCategoryId"] = _jobCategoryService.Dropdown();
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobSubCategory jobSubCategory)
        {
            if (ModelState.IsValid)
            {


                await _jobSubCategoryService.UpdateAsync(jobSubCategory);
                TempData["successAlert"] = "JobSubCatagory update successfull.";

                return RedirectToAction(nameof(Index));

            }

            return View(jobSubCategory);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dc = await _jobSubCategoryService.FindAsync(m => m.Id == id, i => i.JobCategory);
            if (dc == null)
            {
                return NotFound();
            }
            ViewData["JobCategoryId"] = _jobCategoryService.Dropdown();


            return View(dc);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var dc = await _jobSubCategoryService.FindAsync(id);
                if (dc != null)
                {
                    await _jobSubCategoryService.DeleteAsync(dc);
                }
                TempData["successAlert"] = "JobSubCatagory delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            var val = await _jobSubCategoryService.FindAsync(m => m.Id == id, i => i.JobCategory);
            return View(val);
        }




    }
}