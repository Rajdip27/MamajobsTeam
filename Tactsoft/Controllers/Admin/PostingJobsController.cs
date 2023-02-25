using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Tactsoft.Controllers.Admin
{
    public class PostingJobsController : Controller
    {
        private readonly IPostingJobService _jobService;
        private readonly IJobLevelService _jobLevel;
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IWorkPlaceService _workPlace;
        private readonly IJobLocationService _jobLocationService;
        private readonly IEmploymentStatusService _employmentStatusService;
        private readonly IResumeReceivingOptionsService _resumeReceivingOptionsService;
        public PostingJobsController(IPostingJobService jobService, IJobCategoryService jobCategoryService, IJobLevelService jobLevel, IWorkPlaceService workPlace, IJobLocationService jobLocationService, IEmploymentStatusService employmentStatusService, IResumeReceivingOptionsService resumeReceivingOptionsService)
        {
                this._jobService = jobService;
                 _jobCategoryService = jobCategoryService;
            _jobLevel = jobLevel;
            _workPlace = workPlace;
            _jobLocationService = jobLocationService;
            _employmentStatusService = employmentStatusService;
            _resumeReceivingOptionsService = resumeReceivingOptionsService;
        }

        public async Task<IActionResult> Index()
        {
             var Result=await _jobService.GetAllAsync(i => i.JobCategory, x => x.JobLevel, x => x.WorkPlace, x => x.JobLocation,x =>x.ResumeReceivingOption, x => x.EmploymentStatus);
            
            return View(Result);
        }
        public IActionResult Create()
        {
            ViewData["JobCategoryeId"] = _jobCategoryService.Dropdown();
            ViewData["JobLevelId"] = _jobLevel.Dropdown();
            ViewData["WorkPlaceId"] = _workPlace.Dropdown();
            ViewData["JobLocationId"] = _jobLocationService.Dropdown();
            ViewData["EmploymentStatusId"] = _employmentStatusService.Dropdown();
            ViewData["ResumeOptionId"] = _resumeReceivingOptionsService.Dropdown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostingJobs postingJobs, IFormFile pictureFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/PostingJobs", pictureFile.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        postingJobs.Photograph = $"{pictureFile.FileName}";
                    }
                    await _jobService.InsertAsync(postingJobs);
                    TempData["successAlert"] = "Posting Jobs save successfull.";
                    return RedirectToAction(nameof(Index));
                }
                ViewData["JobCategoryeId"] = _jobCategoryService.Dropdown();
                ViewData["JobLevelId"] = _jobLevel.Dropdown();
                ViewData["WorkPlaceId"] = _workPlace.Dropdown();
                ViewData["JobLocationId"] = _jobLocationService.Dropdown();
                ViewData["EmploymentStatusId"] = _employmentStatusService.Dropdown();
                ViewData["ResumeOptionId"] = _resumeReceivingOptionsService.Dropdown();
                TempData["errorAlert"] = "Operation failed.";
                return View(postingJobs);
            }
            catch 
            {
                return View("Create", postingJobs);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var val = await _jobService.FindAsync(id);
            if (val == null)
            {
                return NotFound();
            }
            ViewData["JobCategoryeId"] = _jobCategoryService.Dropdown();
            ViewData["JobLevelId"] = _jobLevel.Dropdown();
            ViewData["WorkPlaceId"] = _workPlace.Dropdown();
            ViewData["JobLocationId"] = _jobLocationService.Dropdown();
            ViewData["EmploymentStatusId"] = _employmentStatusService.Dropdown();
            ViewData["ResumeOptionId"] = _resumeReceivingOptionsService.Dropdown();
            return View(val);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PostingJobs postingJobs, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {

                var emp = await _jobService. FindAsync(postingJobs.Id);
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/PostingJobs", pictureFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    postingJobs.Photograph = $"{pictureFile.FileName}";
                }
                else
                {
                    postingJobs.Photograph = emp.Photograph;
                }
                await _jobService.UpdateAsync(postingJobs);
                TempData["successAlert"] = "company update successfull.";

                return RedirectToAction(nameof(Index));

            }

            return View(postingJobs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var val = await _jobService.FindAsync(m => m.Id == id, i => i.JobCategory, x => x.JobLevel, x => x.WorkPlace, x => x.JobLocation, x => x.ResumeReceivingOption , x => x.EmploymentStatus);
            return View(val);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var val = await _jobService.FindAsync(m => m.Id == id, i => i.JobCategory, x => x.JobLevel, x => x.WorkPlace, x => x.JobLocation, x => x.ResumeReceivingOption, x => x.EmploymentStatus);

            if (val == null)
            {
                return NotFound();
            }
            ViewData["JobCategoryeId"] = _jobCategoryService.Dropdown();
            ViewData["JobLevelId"] = _jobLevel.Dropdown();
            ViewData["WorkPlaceId"] = _workPlace.Dropdown();
            ViewData["JobLocationId"] = _jobLocationService.Dropdown();
            ViewData["EmploymentStatusId"] = _employmentStatusService.Dropdown();
            ViewData["ResumeOptionId"] = _resumeReceivingOptionsService.Dropdown();
            return View(val);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var dc = await _jobService.FindAsync(id);
                if (dc != null)
                {
                    await _jobService.DeleteAsync(dc);
                }
                TempData["successAlert"] = "Posting Jobs delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }


    }
}
