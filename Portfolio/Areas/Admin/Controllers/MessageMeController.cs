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
    public class MessageMeController : Controller
    {
        private readonly AppDbContext db;
        public MessageMeController(AppDbContext dbs)
        {
            db = dbs;
        }
        public IActionResult Index()
        {
            ViewBag.MessageCount = db.MessageMe.Count();
            return View(db.MessageMe);
        }
    }
}