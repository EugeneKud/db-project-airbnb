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
    public class AmenityTypesController : Controller
    {
        private readonly ModelContext _context;

        public AmenityTypesController(ModelContext context)
        {
            _context = context;
        }

        // GET: AmenityTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AmenityTypes.ToListAsync());
        }

        // GET: AmenityTypes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenityType = await _context.AmenityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amenityType == null)
            {
                return NotFound();
            }

            return View(amenityType);
        }

        // GET: AmenityTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AmenityTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AmenityType amenityType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amenityType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amenityType);
        }

        // GET: AmenityTypes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenityType = await _context.AmenityTypes.FindAsync(id);
            if (amenityType == null)
            {
                return NotFound();
            }
            return View(amenityType);
        }

        // POST: AmenityTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Name")] AmenityType amenityType)
        {
            if (id != amenityType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amenityType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenityTypeExists(amenityType.Id))
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
            return View(amenityType);
        }

        // GET: AmenityTypes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenityType = await _context.AmenityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amenityType == null)
            {
                return NotFound();
            }

            return View(amenityType);
        }

        // POST: AmenityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var amenityType = await _context.AmenityTypes.FindAsync(id);
            _context.AmenityTypes.Remove(amenityType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmenityTypeExists(decimal id)
        {
            return _context.AmenityTypes.Any(e => e.Id == id);
        }
    }
}
