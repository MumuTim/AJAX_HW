using AJAX_HW.Models;
using Microsoft.AspNetCore.Mvc;

namespace AJAX_HW.Controllers
{
    public class ApiController : Controller
    {
        private DemoContext _context;

        public ApiController(DemoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cities()
        {
            var cities = _context.Address.Select(x => x.City).Distinct();

            return Json(cities);
        }

        public IActionResult Districts(string city)
        {
            var districts = _context.Address.Where(x => x.City == city).Select(x => x.SiteId).Distinct();

            return Json(districts);
        }

        public IActionResult Roads(string district)
        {
            var roads = _context.Address.Where(x => x.SiteId == district).Select(x => x.Road).Distinct();

            return Json(roads);
        }
    }
}
