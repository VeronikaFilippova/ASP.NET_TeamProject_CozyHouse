using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class GuestHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
