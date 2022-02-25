using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using news_site.Models;

namespace news_site.Controllers
{
    [Area("AdminPanel")]

    public class TeamMembersController : Controller
    {
        private readonly DbSiteContext _context;
        private readonly IWebHostEnvironment _webHostingEnviroment;

        public TeamMembersController(DbSiteContext context,IWebHostEnvironment webHostingEnviroment)
        {
            _context = context;
            this._webHostingEnviroment = webHostingEnviroment;
        }

        // GET: TeamMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamMember.ToListAsync());
        }

        // GET: TeamMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _context.TeamMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        // GET: TeamMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                string filename = string.Empty;
                if (teamMember.File != null)
                {
                    string wwwRoot = Path.Combine(_webHostingEnviroment.WebRootPath, "Images/Team-Members");
                    filename = teamMember.File.FileName;
                    
                    //string uniqeFileName = new Guid() + ".jpg";
                    string fullPath = Path.Combine(wwwRoot,filename);
                    using (var filestream = new FileStream(fullPath, FileMode.Create))
                    {
                        teamMember.File.CopyTo(filestream);
                    }
                    teamMember.Image = filename;
                }
                _context.Add(teamMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamMember);
        }

        // GET: TeamMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _context.TeamMember.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            return View(teamMember);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,TeamMember teamMember)
        {
            if (id != teamMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    string filename = string.Empty;
                    if (teamMember.File != null)
                    {
                        string wwwRoot = Path.Combine(_webHostingEnviroment.WebRootPath, "Images/Team-Members");
                        filename = teamMember.File.FileName;

                        //string uniqeFileName = new Guid() + ".jpg";
                        string fullPath = Path.Combine(wwwRoot, filename);
                        using (var filestream = new FileStream(fullPath, FileMode.Create))
                        {
                            teamMember.File.CopyTo(filestream);
                        }
                        teamMember.Image = filename;
                    }
                    _context.Update(teamMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamMemberExists(teamMember.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teamMember);
        }

        // GET: TeamMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _context.TeamMember
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamMember = await _context.TeamMember.FindAsync(id);
            _context.TeamMember.Remove(teamMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamMemberExists(int id)
        {
            return _context.TeamMember.Any(e => e.Id == id);
        }
    }
}
