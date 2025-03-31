using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class HomeController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        IShelterPetPublicationRepository _shelterPetPublicationRepository;
        IUserPetPublicationRepository _userPetPublicationRepository;
        public HomeController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
            IShelterPetPublicationRepository publications, IUserPetPublicationRepository userPublications, IShelterAdoptionRequestRepository requests)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _shelterPetPublicationRepository = publications;
            _userPetPublicationRepository = userPublications;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SeeShelterPublications()
        {
            return View(_shelterPetPublicationRepository.GetAll());
        }
        public IActionResult SeeUserPublications()
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            return View(_userPetPublicationRepository.GetAll().Where(publication => publication.OwnerId != userId));
        }
        public IActionResult SeeMoreShelterPublication(Guid id)
        {
            return View(_shelterPetPublicationRepository.Read(id));
        }
        public IActionResult SeeMoreUserPublication(Guid id)
        {
            return View(_userPetPublicationRepository.Read(id));
        }
        public async Task<IActionResult> LogoutCommand()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public async Task<IActionResult> DeleteAccount()
        {
            ApplicationUser? user = await _userManager.GetUserAsync(User);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAccount(ApplicationUser user)
        {
            await _signInManager.SignOutAsync();
            ApplicationUser? userToDelete = await _userManager.FindByIdAsync(user.Id.ToString());
            await _userManager.DeleteAsync(userToDelete!);
            return RedirectToAction("Index", "Home", new { area = "" }); ;
        }
    }
}
