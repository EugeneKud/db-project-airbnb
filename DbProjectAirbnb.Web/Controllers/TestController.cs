using Microsoft.AspNetCore.Mvc;

namespace DbProjectAirbnb.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}