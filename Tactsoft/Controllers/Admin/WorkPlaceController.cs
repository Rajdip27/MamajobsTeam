using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class WorkPlaceController : Controller
    {
        private readonly IWorkPlaceService _workPlaceService;

        public WorkPlaceController(IWorkPlaceService workPlaceServic)
        {
            this._workPlaceService = workPlaceServic;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _workPlaceService.GetAllAsync();
            return View(val);
        }

        // GET: WorkPlaceController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var val = await _workPlaceService.FindAsync(id);
            return View(val);
        }

        // GET: JobCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkPlaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkPlace workPlace)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _workPlaceService.InsertAsync(workPlace);
                }
                TempData["successAlert"] = "workPlace  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkPlaceController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var val = await _workPlaceService.FindAsync(id);
            return View(val);
        }

        // POST: WorkPlaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WorkPlace workPlace)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _workPlaceService.UpdateAsync(workPlace);
                }

                TempData["successAlert"] = "workPlace update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkPlaceController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var val = await _workPlaceService.FindAsync(id);
            return View(val);
        }

        // POST: WorkPlaceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _workPlaceService.FindAsync(id);
                if (val != null)
                {
                    await _workPlaceService.DeleteAsync(val);
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