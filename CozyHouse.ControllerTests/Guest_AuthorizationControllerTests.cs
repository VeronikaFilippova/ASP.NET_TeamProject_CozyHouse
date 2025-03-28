using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.UI.Areas.Guest.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace CozyHouse.ControllerTests
{
    public class Guest_AuthorizationControllerTests
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;

        AuthorizationController authorizationController;
        public Guest_AuthorizationControllerTests()
        {
            _userManagerMock = new Mock<UserManager<ApplicationUser>>();
            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>();

            _userManager = _userManagerMock.Object;
            _signInManager = _signInManagerMock.Object;

            authorizationController = new AuthorizationController(_userManager, _signInManager);
        }

        [Fact]
        public void Test()
        {
        }
    }
}
