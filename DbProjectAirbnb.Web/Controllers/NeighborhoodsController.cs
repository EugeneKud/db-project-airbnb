using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbProjectAirbnb.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DbProjectAirbnb.Web.Controllers
{
    public class NeighborhoodsController : Controller
    {
        private readonly ModelContext _context;

        public NeighborhoodsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Neighborhoods
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Neighborhoods.Include(n => n.City);
            return View(await modelContext.ToListAsync());
        }

        // GET: Neighborhoods/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods
                .Include(n => n.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        // GET: Neighborhoods/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            return View();
        }

        // POST: Neighborhoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CityId")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(neighborhood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", neighborhood.CityId);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods.FindAsync(id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", neighborhood.CityId);
            return View(neighborhood);
        }

        // POST: Neighborhoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Name,CityId")] Neighborhood neighborhood)
        {
            if (id != neighborhood.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neighborhood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeighborhoodExists(neighborhood.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", neighborhood.CityId);
            return View(neighborhood);
        }

        // GET: Neighborhoods/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods
                .Include(n => n.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        // POST: Neighborhoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var neighborhood = await _context.Neighborhoods.FindAsync(id);
            _context.Neighborhoods.Remove(neighborhood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeighborhoodExists(decimal id)
        {
            return _context.Neighborhoods.Any(e => e.Id == id);
        }
    }
}
