using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL;
using Portfolio.Models;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutMeController : Controller
    {
        private readonly AppDbContext db;
        public AboutMeController(AppDbContext dtbs)
        {
            db = dtbs;
        }
        public IActionResult Index()
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            return View(db.AboutMe.First(a=>a.Id==1));
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            AboutMe about = await db.AboutMe.FindAsync(id);
            return View(about);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AboutMe about)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            db.Entry(about).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}