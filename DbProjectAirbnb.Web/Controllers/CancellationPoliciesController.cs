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
    public class CancellationPoliciesController : Controller
    {
        private readonly ModelContext _context;

        public CancellationPoliciesController(ModelContext context)
        {
            _context = context;
        }

        // GET: CancellationPolicies
        public async Task<IActionResult> Index()
        {
            return View(await _context.CancellationPolicies.ToListAsync());
        }

        // GET: CancellationPolicies/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancellationPolicy = await _context.CancellationPolicies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cancellationPolicy == null)
            {
                return NotFound();
            }

            return View(cancellationPolicy);
        }

        // GET: CancellationPolicies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CancellationPolicies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CancellationPolicy cancellationPolicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cancellationPolicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cancellationPolicy);
        }

        // GET: CancellationPolicies/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancellationPolicy = await _context.CancellationPolicies.FindAsync(id);
            if (cancellationPolicy == null)
            {
                return NotFound();
            }
            return View(cancellationPolicy);
        }

        // POST: CancellationPolicies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Name")] CancellationPolicy cancellationPolicy)
        {
            if (id != cancellationPolicy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancellationPolicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CancellationPolicyExists(cancellationPolicy.Id))
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
            return View(cancellationPolicy);
        }

        // GET: CancellationPolicies/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancellationPolicy = await _context.CancellationPolicies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cancellationPolicy == null)
            {
                return NotFound();
            }

            return View(cancellationPolicy);
        }

        // POST: CancellationPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var cancellationPolicy = await _context.CancellationPolicies.FindAsync(id);
            _context.CancellationPolicies.Remove(cancellationPolicy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CancellationPolicyExists(decimal id)
        {
            return _context.CancellationPolicies.Any(e => e.Id == id);
        }
    }
}
