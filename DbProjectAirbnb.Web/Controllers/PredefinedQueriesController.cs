using Microsoft.AspNetCore.Mvc;

namespace DbProjectAirbnb.Web.Controllers
{
    public class PredefinedQueriesController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}