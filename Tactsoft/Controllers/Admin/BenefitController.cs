using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class BenefitController : Controller
    {
        private readonly IBenefitService _benefitService;
        private readonly IJobPostService _jobPostService;
        private readonly IOtherBenefitTypeService _otherBenefitTypeService;

        public BenefitController(IBenefitService benefitService, IJobPostService jobPostService, IOtherBenefitTypeService otherBenefitTypeService)
        {
            _benefitService = benefitService;
            this._jobPostService = jobPostService;
            this._otherBenefitTypeService = otherBenefitTypeService;
        }

        public async Task<IActionResult> Index()
        {

            var val = await _benefitService.GetAllAsync(i => i.OtherBenefitType, x => x.JobPost);
            return View(val);
        }


        public IActionResult Create()
        {
            ViewData["JobPostId"] = _jobPostService.Dropdown();
            ViewData["OtherBenefitTypeId"] = _otherBenefitTypeService.Dropdown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Benefit benefit)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    await _benefitService.InsertAsync(benefit);
                }
                TempData["successAlert"] = "benefit  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create", benefit);
            }



        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _benefitService.FindAsync(id);
            if (val == null)
            {
                return NotFound();
            }

            ViewData["JobPostId"] = _jobPostService.Dropdown();
            ViewData["OtherBenefitTypeId"] = _otherBenefitTypeService.Dropdown();

            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Benefit benefit)
        {
            if (ModelState.IsValid)
            {


                await _benefitService.UpdateAsync(benefit);
                TempData["successAlert"] = "Benefit update successfull.";

                return RedirectToAction(nameof(Index));

            }

            return View(benefit);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dc = await _benefitService.FindAsync(m => m.Id == id, i => i.JobPost, x => x.OtherBenefitType);
            if (dc == null)
            {
                return NotFound();
            }
            ViewData["JobPostId"] = _jobPostService.Dropdown();
            ViewData["OtherBenefitTypeId"] = _otherBenefitTypeService.Dropdown();



            return View(dc);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var dc = await _benefitService.FindAsync(id);
                if (dc != null)
                {
                    await _benefitService.DeleteAsync(dc);
                }
                TempData["successAlert"] = "Benefit delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            var val = await _benefitService.FindAsync(m => m.Id == id, i => i.JobPost, x => x.OtherBenefitType);
            return View(val);
        }




    }
}