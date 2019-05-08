using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbProjectAirbnb.Web.Model;

namespace DbProjectAirbnb.Web.Controllers
{
    public class HostsController : Controller
    {
        private readonly ModelContext _context;

        public HostsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Hosts
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Hosts.Include(h => h.IdNavigation).Include(h => h.Neighborhood);
            return View(await modelContext.ToListAsync());
        }

        // GET: Hosts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var host = await _context.Hosts
                .Include(h => h.IdNavigation)
                .Include(h => h.Neighborhood)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (host == null)
            {
                return NotFound();
            }

            return View(host);
        }

        // GET: Hosts/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Name");
            return View();
        }

        // POST: Hosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,About,NeighborhoodId,PictureUrl,ResponseRate,ResponseTime,Since,ThumbnailUrl,Url")] Host host)
        {
            if (ModelState.IsValid)
            {
                _context.Add(host);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", host.Id);
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Name", host.NeighborhoodId);
            return View(host);
        }

        // GET: Hosts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var host = await _context.Hosts.FindAsync(id);
            if (host == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", host.Id);
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Name", host.NeighborhoodId);
            return View(host);
        }

        // POST: Hosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,About,NeighborhoodId,PictureUrl,ResponseRate,ResponseTime,Since,ThumbnailUrl,Url")] Host host)
        {
            if (id != host.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(host);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostExists(host.Id))
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
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", host.Id);
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Name", host.NeighborhoodId);
            return View(host);
        }

        // GET: Hosts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var host = await _context.Hosts
                .Include(h => h.IdNavigation)
                .Include(h => h.Neighborhood)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (host == null)
            {
                return NotFound();
            }

            return View(host);
        }

        // POST: Hosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var host = await _context.Hosts.FindAsync(id);
            _context.Hosts.Remove(host);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostExists(decimal id)
        {
            return _context.Hosts.Any(e => e.Id == id);
        }
    }
}
