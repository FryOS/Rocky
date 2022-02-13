using Microsoft.AspNetCore.Mvc;

namespace Rocky.Controllers
{
    public class ShelfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Get - Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
