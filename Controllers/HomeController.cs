using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using news_site.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace news_site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbSiteContext db;

        public HomeController(ILogger<HomeController> logger, DbSiteContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            var CategoryList = db.Category.ToList();
            return View(CategoryList);
        }

        public IActionResult showSelectedNews(int id)
        {
            Category c = db.Category.Find(id);
            ViewBag.catName = c.Name;
            var selectedNews = db.News.Where(n => n.CategoryId == id).OrderByDescending(n => n.CategoryId == id).ToList();
            return View(selectedNews);
        }
        public IActionResult deleteNews(int id)
        {
            var searchForNews = db.News.Find(id);
            db.News.Remove(searchForNews);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ContactUs()
        {
            return View();
        }


        [HttpPost]
        public IActionResult postContactUs(ContactUs newcontact)
        {
            if (ModelState.IsValid)
            {
                db.ContactUs.Add(newcontact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("ContactUs", newcontact);

        }

        public IActionResult ShowMessage()
        {
            var contactsList = db.ContactUs.ToList();
            return View(contactsList);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
