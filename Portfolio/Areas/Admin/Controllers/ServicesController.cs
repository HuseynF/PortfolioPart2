using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL;
using Portfolio.Extentions;
using Portfolio.Helpers;
using Portfolio.Models;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ServicesController : Controller
    {
        private readonly AppDbContext db;
        private readonly IWebHostEnvironment env;
        public ServicesController(AppDbContext dtbs,IWebHostEnvironment envr)
        {
            db = dtbs;
            env = envr;
        }
        public IActionResult Index()
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            return View(db.Services);
        }
        public IActionResult Create()
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Services service)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!service.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "This is not image");
                return View();
            }
            if (service.Photo.LessThan(2))
            {
                ModelState.AddModelError("Photo", "Image must be max 2mb");
                return View();
            }
            string filename = await service.Photo.SavePhoto(env.WebRootPath, "img");
            service.Image = filename;
            await db.Services.AddAsync(service);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            Services service = await db.Services.FindAsync(id);
            if (service == null) return NotFound();
            return View(service);
        }
        [HttpPost, ValidateAntiForgeryToken, ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteWork(int id)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            Services service = await db.Services.FindAsync(id);
            if (service == null) return NotFound();
            FileHelper.DeleteImg(env.WebRootPath, "img", service.Image);
            db.Services.Remove(service);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            Services service = await db.Services.FindAsync(id);
            if (service == null) return NotFound();
            return View(service);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Services service)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            Services services = await db.Services.FindAsync(id);
            services.Head = service.Head;
            services.Text = service.Text;
            if (service.Photo != null)
            {
                if (!service.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "This is not image");
                    return View();
                }
                if (service.Photo.LessThan(2))
                {
                    ModelState.AddModelError("Photo", "Image must be max 2mb");
                    return View();
                }
                Services service1 = await db.Services.FindAsync(id);
                FileHelper.DeleteImg(env.WebRootPath, "img", service1.Image);
                string filename = await service.Photo.SavePhoto(env.WebRootPath, "img");
                service1.Image = filename;
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}