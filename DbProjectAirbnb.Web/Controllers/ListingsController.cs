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
    public class ListingsController : Controller
    {
        private readonly ModelContext _context;

        public ListingsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Listings
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Listings.Include(l => l.BedType).Include(l => l.CancellationPolicy).Include(l => l.Host).Include(l => l.Neighborhood).Include(l => l.PropertyType).Include(l => l.RoomType);
            return View(await modelContext.ToListAsync());
        }

        // GET: Listings/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listings
                .Include(l => l.BedType)
                .Include(l => l.CancellationPolicy)
                .Include(l => l.Host)
                .Include(l => l.Neighborhood)
                .Include(l => l.PropertyType)
                .Include(l => l.RoomType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        // GET: Listings/Create
        public IActionResult Create()
        {
            ViewData["BedTypeId"] = new SelectList(_context.BedTypes, "Id", "Name");
            ViewData["CancellationPolicyId"] = new SelectList(_context.CancellationPolicies, "Id", "Name");
            ViewData["HostId"] = new SelectList(_context.Hosts, "Id", "PictureUrl");
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Name");
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "Name");
            ViewData["RoomTypeId"] = new SelectList(_context.RoomTypes, "Id", "Name");
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Access,Accommodates,Bathrooms,BedTypeId,Bedrooms,CancellationPolicyId,CleaningFee,Description,ExtraPeople,GuestsIncluded,HostId,HouseRules,Interaction,IsBusinessTravelReady,Latitude,ListingUrl,Longitude,MaximumNights,MinimumNights,MonthlyPrice,Name,NeighborhoodId,NeighborhoodOverview,Notes,PictureUrl,Price,PropertyTypeId,RequireGuestPhoneVerification,RequireGuestProfilePicture,ReviewScoresAccuracy,ReviewScoresCheckin,ReviewScoresCleanliness,ReviewScoresCommunication,ReviewScoresLocation,ReviewScoresRating,ReviewScoresValue,RoomTypeId,SecurityDeposit,Space,SquareFeet,Summary,Transit,WeeklyPrice")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BedTypeId"] = new SelectList(_context.BedTypes, "Id", "Name", listing.BedTypeId);
            ViewData["CancellationPolicyId"] = new SelectList(_context.CancellationPolicies, "Id", "Name", listing.CancellationPolicyId);
            ViewData["HostId"] = new SelectList(_context.Hosts, "Id", "PictureUrl", listing.HostId);
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Name", listing.NeighborhoodId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "Name", listing.PropertyTypeId);
            ViewData["RoomTypeId"] = new SelectList(_context.RoomTypes, "Id", "Name", listing.RoomTypeId);
            return View(listing);
        }

        // GET: Listings/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listings.FindAsync(id);
            if (listing == null)
            {
                return NotFound();
            }
            ViewData["BedTypeId"] = new SelectList(_context.BedTypes, "Id", "Name", listing.BedTypeId);
            ViewData["CancellationPolicyId"] = new SelectList(_context.CancellationPolicies, "Id", "Name", listing.CancellationPolicyId);
            ViewData["HostId"] = new SelectList(_context.Hosts, "Id", "PictureUrl", listing.HostId);
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Name", listing.NeighborhoodId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "Name", listing.PropertyTypeId);
            ViewData["RoomTypeId"] = new SelectList(_context.RoomTypes, "Id", "Name", listing.RoomTypeId);
            return View(listing);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Access,Accommodates,Bathrooms,BedTypeId,Bedrooms,CancellationPolicyId,CleaningFee,Description,ExtraPeople,GuestsIncluded,HostId,HouseRules,Interaction,IsBusinessTravelReady,Latitude,ListingUrl,Longitude,MaximumNights,MinimumNights,MonthlyPrice,Name,NeighborhoodId,NeighborhoodOverview,Notes,PictureUrl,Price,PropertyTypeId,RequireGuestPhoneVerification,RequireGuestProfilePicture,ReviewScoresAccuracy,ReviewScoresCheckin,ReviewScoresCleanliness,ReviewScoresCommunication,ReviewScoresLocation,ReviewScoresRating,ReviewScoresValue,RoomTypeId,SecurityDeposit,Space,SquareFeet,Summary,Transit,WeeklyPrice")] Listing listing)
        {
            if (id != listing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListingExists(listing.Id))
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
            ViewData["BedTypeId"] = new SelectList(_context.BedTypes, "Id", "Name", listing.BedTypeId);
            ViewData["CancellationPolicyId"] = new SelectList(_context.CancellationPolicies, "Id", "Name", listing.CancellationPolicyId);
            ViewData["HostId"] = new SelectList(_context.Hosts, "Id", "PictureUrl", listing.HostId);
            ViewData["NeighborhoodId"] = new SelectList(_context.Neighborhoods, "Id", "Name", listing.NeighborhoodId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "Name", listing.PropertyTypeId);
            ViewData["RoomTypeId"] = new SelectList(_context.RoomTypes, "Id", "Name", listing.RoomTypeId);
            return View(listing);
        }

        // GET: Listings/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listings
                .Include(l => l.BedType)
                .Include(l => l.CancellationPolicy)
                .Include(l => l.Host)
                .Include(l => l.Neighborhood)
                .Include(l => l.PropertyType)
                .Include(l => l.RoomType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var listing = await _context.Listings.FindAsync(id);
            _context.Listings.Remove(listing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListingExists(decimal id)
        {
            return _context.Listings.Any(e => e.Id == id);
        }
    }
}
