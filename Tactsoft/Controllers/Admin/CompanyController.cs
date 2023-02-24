using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IEntrepreneurService _entrepreneurService;
        private readonly IDistrictsService _districtsService;
        private readonly IThanaService _thanaService;
        private readonly IIndustialTypeService _industialTypeService;

        public CompanyController(ICompanyService companyService,
            IEntrepreneurService entrepreneurService,
            IDistrictsService districtsService,
            IThanaService thanaService,
            IIndustialTypeService industialTypeService)
        {
            this._companyService = companyService;
            this._entrepreneurService = entrepreneurService;
            this._districtsService = districtsService;

            this._thanaService = thanaService;
            this._industialTypeService = industialTypeService;
        }

        public async Task<IActionResult> Index()
        {

            var val = await _companyService.GetAllAsync(i => i.District, x => x.Thana, x => x.Entrepreneur, x => x.IndustialType);
            return View(val);
        }


        public IActionResult Create()
        {
            ViewData["EntrepreneurId"] = _entrepreneurService.Dropdown();
            ViewData["DistrictId"] = _districtsService.Dropdown();
            ViewData["ThanaId"] = _thanaService.Dropdown();
            ViewData["IndustialTypeId"] = _industialTypeService.Dropdown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    await _companyService.InsertAsync(company);
                }
                TempData["successAlert"] = "company  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create", company);
            }



        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _companyService.FindAsync(id);
            if (val == null)
            {
                return NotFound();
            }

            ViewData["EntrepreneurId"] = _entrepreneurService.Dropdown();
            ViewData["DistrictId"] = _districtsService.Dropdown();
            ViewData["ThanaId"] = _thanaService.Dropdown();
            ViewData["IndustialTypeId"] = _industialTypeService.Dropdown();

            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Company company)
        {
            if (ModelState.IsValid)
            {


                await _companyService.UpdateAsync(company);
                TempData["successAlert"] = "company update successfull.";

                return RedirectToAction(nameof(Index));

            }

            return View(company);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dc = await _companyService.FindAsync(m => m.Id == id, i => i.District, x => x.Thana, x => x.Entrepreneur, x => x.IndustialType);
            if (dc == null)
            {
                return NotFound();
            }
            ViewData["EntrepreneurId"] = _entrepreneurService.Dropdown();
            ViewData["DistrictId"] = _districtsService.Dropdown();
            ViewData["ThanaId"] = _thanaService.Dropdown();
            ViewData["IndustialTypeId"] = _industialTypeService.Dropdown();


            return View(dc);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var dc = await _companyService.FindAsync(id);
                if (dc != null)
                {
                    await _companyService.DeleteAsync(dc);
                }
                TempData["successAlert"] = "company delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            var val = await _companyService.FindAsync(m => m.Id == id, i => i.District, x => x.Thana, x => x.Entrepreneur, x => x.IndustialType);
            return View(val);
        }




    }
}