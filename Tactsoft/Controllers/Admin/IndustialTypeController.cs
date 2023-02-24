using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class IndustialTypeController : Controller
    {
        private readonly IIndustialTypeService _industialTypeService;

        public IndustialTypeController(IIndustialTypeService industialTypeService)
        {
            this._industialTypeService = industialTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var Inds = await _industialTypeService.GetAllAsync();
            return View(Inds);
        }

        // GET: IndustialTypeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Inds = await _industialTypeService.FindAsync(id);
            return View(Inds);
        }

        // GET: IndustialTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndustialTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IndustialType industialType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _industialTypeService.InsertAsync(industialType);
                }
                TempData["successAlert"] = "IndustialType  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndustialTypeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Inds = await _industialTypeService.FindAsync(id);
            return View(Inds);
        }

        // POST: IndustialTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IndustialType industialType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _industialTypeService.UpdateAsync(industialType);
                }

                TempData["successAlert"] = "industialType update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndustialTypeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Inds = await _industialTypeService.FindAsync(id);
            return View(Inds);
        }

        // POST: IndustialTypeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var Inds = await _industialTypeService.FindAsync(id);
                if (Inds != null)
                {
                    await _industialTypeService.DeleteAsync(Inds);
                }
                TempData["successAlert"] = "industialType delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}