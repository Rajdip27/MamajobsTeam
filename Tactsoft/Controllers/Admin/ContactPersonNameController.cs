using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ContactPersonNameController : Controller
    {
        private readonly IContactPersonNameService _contactPersonNameService;

        public ContactPersonNameController(IContactPersonNameService contactPersonNameService)
        {
            this._contactPersonNameService = contactPersonNameService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _contactPersonNameService.GetAllAsync();
            return View(val);
        }


        public async Task<IActionResult> Details(int id)
        {
            var val = await _contactPersonNameService.FindAsync(id);
            return View(val);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactPersonName contactPersonName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactPersonNameService.InsertAsync(contactPersonName);
                }
                TempData["successAlert"] = "contactPersonName  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _contactPersonNameService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactPersonName contactPersonName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactPersonNameService.UpdateAsync(contactPersonName);
                }

                TempData["successAlert"] = "contactPersonName update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var val = await _contactPersonNameService.FindAsync(id);
            return View(val);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _contactPersonNameService.FindAsync(id);
                if (val != null)
                {
                    await _contactPersonNameService.DeleteAsync(val);
                }
                TempData["successAlert"] = "contactPersonName delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}