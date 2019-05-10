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
    public class BedTypesController : Controller
    {
        private readonly ModelContext _context;

        public BedTypesController(ModelContext context)
        {
            _context = context;
        }

        // GET: BedTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BedTypes.ToListAsync());
        }

        // GET: BedTypes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedType = await _context.BedTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bedType == null)
            {
                return NotFound();
            }

            return View(bedType);
        }

        // GET: BedTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BedTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] BedType bedType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bedType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bedType);
        }

        // GET: BedTypes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedType = await _context.BedTypes.FindAsync(id);
            if (bedType == null)
            {
                return NotFound();
            }
            return View(bedType);
        }

        // POST: BedTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Name")] BedType bedType)
        {
            if (id != bedType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bedType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BedTypeExists(bedType.Id))
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
            return View(bedType);
        }

        // GET: BedTypes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedType = await _context.BedTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bedType == null)
            {
                return NotFound();
            }

            return View(bedType);
        }

        // POST: BedTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var bedType = await _context.BedTypes.FindAsync(id);
            _context.BedTypes.Remove(bedType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BedTypeExists(decimal id)
        {
            return _context.BedTypes.Any(e => e.Id == id);
        }
    }
}
