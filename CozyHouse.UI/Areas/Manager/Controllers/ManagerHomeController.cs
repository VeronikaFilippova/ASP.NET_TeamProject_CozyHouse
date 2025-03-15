using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Manager.Controllers
{
    public class ManagerHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
