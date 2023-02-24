using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ContactPersonDesignationController : Controller
    {
        private readonly IContactPersonDesignationService _contactPersonDesignationService;

        public ContactPersonDesignationController(IContactPersonDesignationService contactPersonDesignationService)
        {
            this._contactPersonDesignationService = contactPersonDesignationService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _contactPersonDesignationService.GetAllAsync();
            return View(val);
        }


        public async Task<IActionResult> Details(int id)
        {
            var val = await _contactPersonDesignationService.FindAsync(id);
            return View(val);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactPersonDesignation contactPersonDesignation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactPersonDesignationService.InsertAsync(contactPersonDesignation);
                }
                TempData["successAlert"] = "contactPersonDesignation  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _contactPersonDesignationService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactPersonDesignation contactPersonDesignation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactPersonDesignationService.UpdateAsync(contactPersonDesignation);
                }

                TempData["successAlert"] = "contactPersonDesignation update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var val = await _contactPersonDesignationService.FindAsync(id);
            return View(val);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _contactPersonDesignationService.FindAsync(id);
                if (val != null)
                {
                    await _contactPersonDesignationService.DeleteAsync(val);
                }
                TempData["successAlert"] = "contactPersonDesignation delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}