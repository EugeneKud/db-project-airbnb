using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbProjectAirbnb.Web.Entities;
using DbProjectAirbnb.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbProjectAirbnb.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ModelContext _modelContext;

        public SearchController(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public IActionResult Index()
        {
            return View(new TablesToSearchMask());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(TablesToSearchMask searchMask)
        {
            if (searchMask.AmenityTypes)
            {
                if (searchMask.ResultData is null) searchMask.ResultData = new Dictionary<string, DataTable>();
                var searchQuery = _modelContext.AmenityTypes
                    .Where(e => e.Name.Contains(searchMask.SearchText));
                searchMask.AmenityTypesResult = await searchQuery
                    .Take(10)
                    .ToListAsync();
                searchMask.AmenityTypesResultCount = await searchQuery.CountAsync();
            }

            return View(searchMask);
        }
    }
}