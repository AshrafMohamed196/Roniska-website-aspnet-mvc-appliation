using Microsoft.AspNetCore.Mvc;
using news_site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_site.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class DefaultController : Controller
    {
        private readonly DbSiteContext db;

        public DefaultController(DbSiteContext context)
        {
            this.db = context;
        }

        public IActionResult Index()
        {
            int catCount = db.Category.Count();
            int newsCount = db.News.Count();
            int teamMembersCount = db.TeamMember.Count();
            int contactCount = db.ContactUs.Count();

            return View(new adminNumbers
            {
                category = catCount,
                team = teamMembersCount,
                news = newsCount,
                Message = contactCount
            });
        }
    }
    public class adminNumbers
    {
        public int category { get; set; }
        public int team { get; set; }
        public int news { get; set; }
        public int Message { get; set; }
    }
}
