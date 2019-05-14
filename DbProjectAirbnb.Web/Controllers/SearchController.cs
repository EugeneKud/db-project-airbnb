using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DbProjectAirbnb.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbProjectAirbnb.Web.Controllers
{
    public class SearchController : Controller
    {
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
                searchMask.ResultData.Add("AmenityTypes", new DataTable());
            }
            return View(searchMask);
        }
    }
}