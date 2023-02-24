using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ContactPersonEmailController : Controller
    {
        private readonly IContactPersonEmailService _contactPersonEmailService;

        public ContactPersonEmailController(IContactPersonEmailService contactPersonEmailService)
        {
            this._contactPersonEmailService = contactPersonEmailService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _contactPersonEmailService.GetAllAsync();
            return View(val);
        }


        public async Task<IActionResult> Details(int id)
        {
            var val = await _contactPersonEmailService.FindAsync(id);
            return View(val);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactPersonEmail contactPersonEmail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactPersonEmailService.InsertAsync(contactPersonEmail);
                }
                TempData["successAlert"] = "contactPersonEmail  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _contactPersonEmailService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactPersonEmail contactPersonEmail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactPersonEmailService.UpdateAsync(contactPersonEmail);
                }

                TempData["successAlert"] = "contactPersonEmail update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var val = await _contactPersonEmailService.FindAsync(id);
            return View(val);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _contactPersonEmailService.FindAsync(id);
                if (val != null)
                {
                    await _contactPersonEmailService.DeleteAsync(val);
                }
                TempData["successAlert"] = "contactPersonEmail delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}