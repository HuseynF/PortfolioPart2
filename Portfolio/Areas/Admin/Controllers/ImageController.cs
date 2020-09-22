using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.DAL;
using Portfolio.Extentions;
using Portfolio.Helpers;
using Portfolio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ImageController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ImageController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            ViewBag.MessageCount = _db.MessageMe.Count();
            return View(_db.Images);
        }
        public IActionResult Create()
        {
            ViewBag.MessageCount = _db.MessageMe.Count();
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Image image)
        {
            ViewBag.MessageCount = _db.MessageMe.Count();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!image.Photo1.IsImage())
            {
                ModelState.AddModelError("Photo1", "This is not an image");
                return View();
            }
            if (!image.Photo2.IsImage())
            {
                ModelState.AddModelError("Photo2", "This is not an image");
                return View();
            }
            if (!image.Photo3.IsImage())
            {
                ModelState.AddModelError("Photo3", "This is not an image");
                return View();
            }
            if (image.Photo1.LessThan(2))
            {
                ModelState.AddModelError("Photo1", "Image must be less than 2 mb");
                return View();
            }
            if (image.Photo2.LessThan(2))
            {
                ModelState.AddModelError("Photo2", "Image must be less than 2 mb");
                return View();
            }
            if (image.Photo3.LessThan(2))
            {
                ModelState.AddModelError("Photo3", "Image must be less than 2 mb");
                return View();
            }
            string filename1 = await image.Photo1.SavePhoto(_env.WebRootPath, "img");
            image.Image1 = filename1;
            string filename2 = await image.Photo2.SavePhoto(_env.WebRootPath, "img");
            image.Image2 = filename2;
            string filename3 = await image.Photo3.SavePhoto(_env.WebRootPath, "img");
            image.Image3 = filename3;
            await _db.Images.AddAsync(image);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.MessageCount = _db.MessageMe.Count();
            Image image = await _db.Images.FindAsync(id);
            if (image == null) return NotFound();
            return View(image);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Image image)
        {
            ViewBag.MessageCount = _db.MessageMe.Count();
            if (!image.Photo1.IsImage())
            {
                ModelState.AddModelError("Photo1", "This is not an image");
                return View();
            }
            if (image.Photo1.LessThan(2))
            {
                ModelState.AddModelError("Photo1", "Image must be less than 2 mb");
                return View();
            }
            Image imagepro = await _db.Images.FindAsync(id);
            FileHelper.DeleteImg(_env.WebRootPath, "img", imagepro.Image1);
            string filename1 = await image.Photo1.SavePhoto(_env.WebRootPath, "img");
            imagepro.Image1 = filename1;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update1(int id)
        {
            ViewBag.MessageCount = _db.MessageMe.Count();
            Image image = await _db.Images.FindAsync(id);
            if (image == null) return NotFound();
            return View(image);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update1(int id, Image image)
        {
            ViewBag.MessageCount = _db.MessageMe.Count();
            if (!image.Photo2.IsImage())
            {
                ModelState.AddModelError("Photo2", "This is not an image");
                return View();
            }
            if (image.Photo2.LessThan(2))
            {
                ModelState.AddModelError("Photo2", "Image must be less than 2 mb");
                return View();
            }
            Image imagepro = await _db.Images.FindAsync(id);
            FileHelper.DeleteImg(_env.WebRootPath, "img", imagepro.Image2);
            string filename2 = await image.Photo2.SavePhoto(_env.WebRootPath, "img");
            imagepro.Image2 = filename2;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update2(int id)
        {
            ViewBag.MessageCount = _db.MessageMe.Count();
            Image image = await _db.Images.FindAsync(id);
            if (image == null) return NotFound();
            return View(image);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update2(int id, Image image)
        {
            ViewBag.MessageCount = _db.MessageMe.Count();
            if (!image.Photo3.IsImage())
            {
                ModelState.AddModelError("Photo3", "This is not an image");
                return View();
            }
            if (image.Photo3.LessThan(2))
            {
                ModelState.AddModelError("Photo3", "Image must be less than 2 mb");
                return View();
            }
            Image imagepro = await _db.Images.FindAsync(id);
            FileHelper.DeleteImg(_env.WebRootPath, "img", imagepro.Image3);
            string filename3 = await image.Photo3.SavePhoto(_env.WebRootPath, "img");
            imagepro.Image3 = filename3;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.MessageCount = _db.MessageMe.Count();
            Image image = await _db.Images.FindAsync(id);
            if (image == null) return NotFound();
            return View(image);
        }
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public async Task<IActionResult> DeleteImg(int id)
        {
            ViewBag.MessageCount = _db.MessageMe.Count();
            if (_db.Images.Count() != 1)
            {
                Image image = await _db.Images.FindAsync(id);
                if (image == null) return NotFound();
                FileHelper.DeleteImg(_env.WebRootPath, "img", image.Image1);
                FileHelper.DeleteImg(_env.WebRootPath, "img", image.Image2);
                FileHelper.DeleteImg(_env.WebRootPath, "img", image.Image3);
                _db.Images.Remove(image);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return Content("Sorry we've blocked your request!");
        }
    }
}