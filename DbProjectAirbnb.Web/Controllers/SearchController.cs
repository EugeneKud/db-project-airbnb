using Microsoft.AspNetCore.Mvc;

namespace DbProjectAirbnb.Web.Controllers
{
    public class SearchController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}