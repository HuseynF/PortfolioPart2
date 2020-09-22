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
    public class ContactController : Controller
    {
        private readonly AppDbContext db;
        public ContactController(AppDbContext dbs)
        {
            db = dbs;
        }
        public IActionResult Index()
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            return View(db.Contact.First(c=>c.Id==1));
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            Contact contact = await db.Contact.FindAsync(id);
            return View(contact);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Contact contact)
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            db.Entry(contact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}