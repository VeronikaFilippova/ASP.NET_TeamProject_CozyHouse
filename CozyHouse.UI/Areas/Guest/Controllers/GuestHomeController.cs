using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Guest.Controllers
{
    [Area("Guest")]
    [AllowAnonymous]
    public class GuestHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
