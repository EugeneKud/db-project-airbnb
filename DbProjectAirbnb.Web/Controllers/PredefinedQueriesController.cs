using System;
using System.Linq;
using System.Threading.Tasks;
using DbProjectAirbnb.Web.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DbProjectAirbnb.Web.Controllers
{
    [Route("predefined-queries")]
    public class PredefinedQueriesController : Controller
    {
        private readonly ModelContext _modelContext;

        public PredefinedQueriesController(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PredefinedQueryDetails(int id)
        {
            var matchedPredefinedQuery = _modelContext.PredefinedQueries.SingleOrDefault(e => string.Equals(e.Deliverable + e.Order.ToString("00"), id.ToString(), StringComparison.OrdinalIgnoreCase));
            if (matchedPredefinedQuery is null)
                return NotFound();
            return View(matchedPredefinedQuery);
        }
    }
}