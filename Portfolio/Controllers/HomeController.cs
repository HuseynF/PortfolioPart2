using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;
        public HomeController(AppDbContext _db)
        {
           db=_db;
        }
        public IActionResult Index()
        {
            HomeVM home = new HomeVM
            {
                AboutMe = db.AboutMe.First(a => a.Id == 1),
                AboutSkills = db.AboutSkills.First(a => a.Id == 1),
                Contact = db.Contact.First(c => c.Id == 1),
                MyWorks = db.MyWorks.Select(m=>new MyWorks
                {
                    Id=m.Id,
                    Category=m.Category,
                    Image=m.Image,
                    Text=m.Text,
                    Head=m.Head,
                    ShortName=m.ShortName,
                    CloseName=m.CloseName,
                    ModalName=m.ModalName
                }),
                Services = db.Services
            };
            return View(home);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(MessageMe message)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please enter something!");
                HomeVM home = new HomeVM
                {
                    AboutMe = db.AboutMe.First(a => a.Id == 1),
                    AboutSkills = db.AboutSkills.First(a => a.Id == 1),
                    Contact = db.Contact.First(c => c.Id == 1),
                    MyWorks = db.MyWorks.Select(m => new MyWorks
                    {
                        Id = m.Id,
                        Category = m.Category,
                        Image = m.Image,
                        Text = m.Text,
                        Head = m.Head,
                        ShortName = m.ShortName,
                        CloseName = m.CloseName,
                        ModalName = m.ModalName
                    }),
                    Services = db.Services
                };
                return View(home);
            }
            await db.MessageMe.AddAsync(message);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}