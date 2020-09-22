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
    public class SkillsController : Controller
    {
        private readonly AppDbContext db;
        public SkillsController(AppDbContext dtbs)
        {
            db = dtbs;
        }
        public IActionResult Index()
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            return View(db.AboutSkills.First(s=>s.Id==1));
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            AboutSkills about = await db.AboutSkills.FindAsync(id);
            return View(about);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AboutSkills skills)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            db.Entry(skills).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}