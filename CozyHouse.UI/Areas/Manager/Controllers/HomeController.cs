using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class HomeController : Controller
    {
        SignInManager<ApplicationUser> _signInManager;
        IShelterAdoptionRequestRepository _requestsRepository;
        public HomeController(SignInManager<ApplicationUser> signInManager, IShelterAdoptionRequestRepository requests)
        {
            _signInManager = signInManager;
            _requestsRepository = requests;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SeeRequests()
        {
            return View(_requestsRepository.GetAll());
        }
        public async Task<IActionResult> LogoutCommand()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new {area = ""});
        }
        [HttpPost]
        public IActionResult CloseRequest(Guid id)
        {
            _requestsRepository.Delete(id);
            return RedirectToAction("SeeRequests");
        }
    }
}
