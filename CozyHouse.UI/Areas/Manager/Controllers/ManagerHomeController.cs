using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class ManagerHomeController : Controller
    {
        SignInManager<ApplicationUser> _signInManager;
        IRequestRepository _requestsRepository;
        public ManagerHomeController(SignInManager<ApplicationUser> signInManager, IRequestRepository requests)
        {
            _signInManager = signInManager;
            _requestsRepository = requests;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LogoutCommand()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "GuestHome", new { area = "Guest" });
        }

        public IActionResult SeeRequests()
        {
            return View(_requestsRepository.GetAll());
        }
        [HttpPost]
        public IActionResult CloseRequest(Guid id)
        {
            _requestsRepository.Remove(id);
            return RedirectToAction("SeeRequests");
        }
    }
}
