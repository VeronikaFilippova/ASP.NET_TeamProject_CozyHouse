using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ManagerHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
