using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ContactPersonMobileController : Controller
    {
        private readonly IContactPersonMobileService _contactPersonMobileService;

        public ContactPersonMobileController(IContactPersonMobileService contactPersonMobileService)
        {
            this._contactPersonMobileService = contactPersonMobileService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _contactPersonMobileService.GetAllAsync();
            return View(val);
        }


        public async Task<IActionResult> Details(int id)
        {
            var val = await _contactPersonMobileService.FindAsync(id);
            return View(val);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactPersonMobile contactPersonMobile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactPersonMobileService.InsertAsync(contactPersonMobile);
                }
                TempData["successAlert"] = "PersonMobile  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _contactPersonMobileService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactPersonMobile contactPersonMobile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactPersonMobileService.UpdateAsync(contactPersonMobile);
                }

                TempData["successAlert"] = "PersonMobile update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var val = await _contactPersonMobileService.FindAsync(id);
            return View(val);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _contactPersonMobileService.FindAsync(id);
                if (val != null)
                {
                    await _contactPersonMobileService.DeleteAsync(val);
                }
                TempData["successAlert"] = "PersonMobile delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}