using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class UserHomeController : Controller
    {
        SignInManager<ApplicationUser> _signInManager;
        IListingRepository _listingRepository;
        IUserListingsRepository _userListingRepository;
        UserManager<ApplicationUser> _userManager;
        IUserRequestRepository _userRequsetRepository;
        public UserHomeController(SignInManager<ApplicationUser> signInManager, IListingRepository listings, 
            IUserListingsRepository userListings, UserManager<ApplicationUser> userManager, IUserRequestRepository requests)
        {
            _signInManager = signInManager;
            _listingRepository = listings;
            _userListingRepository = userListings;
            _userManager = userManager;
            _userRequsetRepository = requests;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShelterPets()
        {
            return View(_listingRepository.GetAll());
        }
        public IActionResult UserPets()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
            return View(_userListingRepository.GetAll().Where(listing => listing.OwnerId != Guid.Parse(userId)).ToList());
        }
        public IActionResult SeeMore(Guid id)
        {
            return View(_listingRepository.GetListing(id));
        }
        public IActionResult SeeMoreUserPet(Guid id)
        {
            return View(_userListingRepository.GetListing(id));
        }
        public async Task<IActionResult> LogoutCommand()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "GuestHome", new { area = "Guest" });
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
            return RedirectToAction("Index", "GuestHome", new { area = "Guest" }); ;
        }
        public IActionResult SeeAdoptionRequests()
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            return View(_userRequsetRepository.GetAllFor(userId));
        }
    }
}
