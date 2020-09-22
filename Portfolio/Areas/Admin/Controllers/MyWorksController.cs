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
    public class MyWorksController : Controller
    {
        private readonly AppDbContext db;
        public MyWorksController(AppDbContext dbs)
        {
            db = dbs;
        }
        public IActionResult Index()
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            return View(db.MyWorks.Select(w=>new MyWorks
            {
                Id=w.Id,
                Head=w.Head,
                Text=w.Text,
                ModalName=w.ModalName,
                ShortName=w.ShortName,
                CloseName=w.CloseName,
                ImageId=w.ImageId,
                CategoryId=w.CategoryId,
                Image=w.Image,
                Category=w.Category
            }));
        }
        public IActionResult Create()
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MyWorks work)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            await db.MyWorks.AddAsync(work);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            MyWorks work = await db.MyWorks.FindAsync(id);
            if (work==null)
            {
                return NotFound();
            }
            return View(work);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(MyWorks work)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            db.Entry(work).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            MyWorks work = await db.MyWorks.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }
            return View(work);
        }
        [HttpPost,ValidateAntiForgeryToken,ActionName("Delete")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            if (db.MyWorks.Count() != 1)
            {
                MyWorks work = await db.MyWorks.FindAsync(id);
                if (work == null) return NotFound();
                db.MyWorks.Remove(work);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return Content("Sorry we've blocked your request!");
        }
    }
}