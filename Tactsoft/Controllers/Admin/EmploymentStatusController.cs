using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Controllers.Admin
{
    public class EmploymentStatusController : Controller
    {
        private readonly IEmploymentStatusService _employmentStatusService;
     

        public EmploymentStatusController(IEmploymentStatusService employmentStatusService)
        {
            this._employmentStatusService = employmentStatusService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _employmentStatusService.GetAllAsync();
            return View(val);
        }

       
        public async Task<IActionResult> Details(int id)
        {
            var val = await _employmentStatusService.FindAsync(id);
            return View(val);
        }

        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmploymentStatus employmentStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employmentStatusService.InsertAsync(employmentStatus);
                }
                TempData["successAlert"] = "employmentStatus  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public async Task<IActionResult> Edit(int id)
        {
            var val = await _employmentStatusService.FindAsync(id);
            return View(val);
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmploymentStatus employmentStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employmentStatusService.UpdateAsync(employmentStatus);
                }

                TempData["successAlert"] = "EmploymentStatus update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

  
        public async Task<IActionResult> Delete(int id)
        {
            var val = await _employmentStatusService.FindAsync(id);
            return View(val);
        }

   
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _employmentStatusService.FindAsync(id);
                if (val != null)
                {
                    await _employmentStatusService.DeleteAsync(val);
                }
                TempData["successAlert"] = "EmploymentStatus delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}