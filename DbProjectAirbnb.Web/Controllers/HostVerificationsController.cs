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
    public class HostVerificationsController : Controller
    {
        private readonly ModelContext _context;

        public HostVerificationsController(ModelContext context)
        {
            _context = context;
        }

        // GET: HostVerifications
        public async Task<IActionResult> Index()
        {
            return View(await _context.HostVerifications.ToListAsync());
        }

        // GET: HostVerifications/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostVerification = await _context.HostVerifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostVerification == null)
            {
                return NotFound();
            }

            return View(hostVerification);
        }

        // GET: HostVerifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HostVerifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] HostVerification hostVerification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hostVerification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hostVerification);
        }

        // GET: HostVerifications/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostVerification = await _context.HostVerifications.FindAsync(id);
            if (hostVerification == null)
            {
                return NotFound();
            }
            return View(hostVerification);
        }

        // POST: HostVerifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Name")] HostVerification hostVerification)
        {
            if (id != hostVerification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hostVerification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostVerificationExists(hostVerification.Id))
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
            return View(hostVerification);
        }

        // GET: HostVerifications/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostVerification = await _context.HostVerifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostVerification == null)
            {
                return NotFound();
            }

            return View(hostVerification);
        }

        // POST: HostVerifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var hostVerification = await _context.HostVerifications.FindAsync(id);
            _context.HostVerifications.Remove(hostVerification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostVerificationExists(decimal id)
        {
            return _context.HostVerifications.Any(e => e.Id == id);
        }
    }
}
