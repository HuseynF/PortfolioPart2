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
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext db;
        public CategoryController(AppDbContext dbs)
        {
            db = dbs;
        }
        public IActionResult Index()
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            return View(db.Categories);
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            Category category = await db.Categories.FindAsync(id);
            return View(category);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}