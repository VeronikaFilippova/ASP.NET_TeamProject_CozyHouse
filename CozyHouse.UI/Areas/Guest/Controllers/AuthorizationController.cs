using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.UI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Guest.Controllers
{
    [Area("Guest")]
    [AllowAnonymous] // Дозволяє не залогіненим користувачам користуватись методами в середині
    public class AuthorizationController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public AuthorizationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index(RegisterDTO register)
        {
            return View(register);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCommand(RegisterDTO register)
        {
            // TODO: Error handling
            ApplicationUser user = new ApplicationUser()
            {
                UserName = register.Login,
                PersonName = register.UserName,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
            };

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);
            await _userManager.AddToRoleAsync(user, "User");

            if (result.Succeeded == true)
            {
                return RedirectToAction("Login", new LoginDTO() { UserLogin = register.Login, UserPassword = register.Password });
            }
            return RedirectToAction("Index", register);
        }

        public IActionResult Login(LoginDTO login)
        {
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> LoginCommand(LoginDTO login)
        {
            if (login.UserLogin == null || login.UserPassword == null) return RedirectToAction("Login", login);

            var result = await _signInManager.PasswordSignInAsync(login.UserLogin, login.UserPassword, false, false);

            if (result.Succeeded)
            {
                ApplicationUser? user = await _userManager.FindByNameAsync(login.UserLogin);
                if (await _userManager.IsInRoleAsync(user!, "User"))
                {
                    return RedirectToAction("Index", "UserHome", new { area = "User" });
                }
                else
                {
                    return RedirectToAction("Index", "ManagerHome", new { area = "Manager" });
                }
            }
            return RedirectToAction("Login", login);
        }
    }
}
