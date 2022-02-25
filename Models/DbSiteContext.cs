using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_site.Models
{
    public class DbSiteContext : DbContext
    {
        public DbSiteContext(DbContextOptions<DbSiteContext> options) : base(options)
        {


        }
        public DbSet<Category> Category { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
    }
}
