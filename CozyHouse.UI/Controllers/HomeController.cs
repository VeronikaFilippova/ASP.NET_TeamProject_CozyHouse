using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Controllers
{
    public class HomeController : Controller
    {
        IListingService service;
        public HomeController(IListingService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
