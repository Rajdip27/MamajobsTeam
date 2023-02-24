using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class CompanyAdressController : Controller
    {
        private readonly ICompanyAdressService _companyAdressService;

        public CompanyAdressController(ICompanyAdressService companyAdressService)
        {
            this._companyAdressService = companyAdressService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _companyAdressService.GetAllAsync();
            return View(val);
        }


        public async Task<IActionResult> Details(int id)
        {
            var val = await _companyAdressService.FindAsync(id);
            return View(val);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyAdress companyAdress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _companyAdressService.InsertAsync(companyAdress);
                }
                TempData["successAlert"] = "companyAdress  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _companyAdressService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CompanyAdress companyAdress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _companyAdressService.UpdateAsync(companyAdress);
                }

                TempData["successAlert"] = "companyAdress update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var val = await _companyAdressService.FindAsync(id);
            return View(val);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _companyAdressService.FindAsync(id);
                if (val != null)
                {
                    await _companyAdressService.DeleteAsync(val);
                }
                TempData["successAlert"] = "companyAdress delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}