using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.Helpers;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class HomeController : Controller
    {
        IAuthorizationManageService _authorizationService;
        IShelterPetPublicationService _shelterPetPublicationService;
        IUserPetPublicationService _userPetPublicationService;
        public HomeController(IAuthorizationManageService authorizationService, IShelterPetPublicationService shelterPublications, IUserPetPublicationService userPublications)
        {
            _authorizationService = authorizationService;
            _shelterPetPublicationService = shelterPublications;
            _userPetPublicationService = userPublications;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SeeShelterPublications()
        {
            return View(_shelterPetPublicationService.GetAll());
        }
        public IActionResult SeeUserPublications()
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            return View(_userPetPublicationService.GetAll().Where(publication => publication.OwnerId != userId));
        }
        public IActionResult SeeMoreShelterPublication(Guid id)
        {
            return View(_shelterPetPublicationService.Get(id));
        }
        public IActionResult SeeMoreUserPublication(Guid id)
        {
            return View(_userPetPublicationService.Get(id));
        }
        public async Task<IActionResult> LogoutCommand()
        {
            await _authorizationService.LogoutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public async Task<IActionResult> DeleteAccount()
        {
            ApplicationUser? user = await _authorizationService.GetUserAsync(User.GetUserId());
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAccount(ApplicationUser user)
        {
            await _authorizationService.LogoutAsync();
            await _authorizationService.DeleteAsync(User.GetUserId());
            return RedirectToAction("Index", "Home", new { area = "" }); ;
        }
    }
}
