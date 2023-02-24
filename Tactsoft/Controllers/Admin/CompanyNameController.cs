using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class CompanyNameController : Controller
    {
        private readonly ICompanyNamesService _companyNameService;

        public CompanyNameController(ICompanyNamesService companyNamesService)
        {
            this._companyNameService = companyNamesService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _companyNameService.GetAllAsync();
            return View(val);
        }

   
        public async Task<IActionResult> Details(int id)
        {
            var val = await _companyNameService.FindAsync(id);
            return View(val);
        }

   
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyName companyName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _companyNameService.InsertAsync(companyName);
                }
                TempData["successAlert"] = "companyName  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
        public async Task<IActionResult> Edit(int id)
        {
            var val = await _companyNameService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CompanyName companyName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _companyNameService.UpdateAsync(companyName);
                }

                TempData["successAlert"] = "companyName update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

     
        public async Task<IActionResult> Delete(int id)
        {
            var val = await _companyNameService.FindAsync(id);
            return View(val);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _companyNameService.FindAsync(id);
                if (val != null)
                {
                    await _companyNameService.DeleteAsync(val);
                }
                TempData["successAlert"] = "companyName delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}