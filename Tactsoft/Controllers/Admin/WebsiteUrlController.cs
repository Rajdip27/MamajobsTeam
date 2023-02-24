using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class WebsiteUrlController : Controller
    {
        private readonly IWebsiteUrlService _websiteUrlService;

        public WebsiteUrlController(IWebsiteUrlService websiteUrlService)
        {
            this._websiteUrlService = websiteUrlService;
        }

        public async Task<IActionResult> Index()
        {
            var val = await _websiteUrlService.GetAllAsync();
            return View(val);
        }


        public async Task<IActionResult> Details(int id)
        {
            var val = await _websiteUrlService.FindAsync(id);
            return View(val);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebsiteUrl websiteUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _websiteUrlService.InsertAsync(websiteUrl);
                }
                TempData["successAlert"] = "websiteUrl  save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var val = await _websiteUrlService.FindAsync(id);
            return View(val);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WebsiteUrl websiteUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _websiteUrlService.UpdateAsync(websiteUrl);
                }

                TempData["successAlert"] = "websiteUrl update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var val = await _websiteUrlService.FindAsync(id);
            return View(val);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var val = await _websiteUrlService.FindAsync(id);
                if (val != null)
                {
                    await _websiteUrlService.DeleteAsync(val);
                }
                TempData["successAlert"] = "websiteUrl delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
