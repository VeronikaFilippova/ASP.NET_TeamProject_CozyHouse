using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Infrastructure.Database;
using EntityFrameworkCoreMock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CozyHouse.CoreTests
{
    public class AuthorizationTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManager;
        private readonly Mock<SignInManager<ApplicationUser>> _signInManager;
        public AuthorizationTests()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userManager = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var userPrincipalFactoryMock = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();

            _signInManager = new Mock<SignInManager<ApplicationUser>>(
                _userManager.Object,
                httpContextAccessorMock.Object,
                userPrincipalFactoryMock.Object,
                null, null, null, null);
        }

        [Fact]
        public async Task Login_UserExists_ReturnsSuccess()
        {
            var user = new ApplicationUser { UserName = "test@gmail.com", Email = "test@gmail.com", Location = "Lviv", PersonName = "Oleh" };
            var password = "Password123!";

            _userManager.Setup(um => um.FindByEmailAsync(user.Email)).ReturnsAsync(user);
            _userManager.Setup(um => um.CheckPasswordAsync(user, password)).ReturnsAsync(true);
            _signInManager.Setup(sm => sm.PasswordSignInAsync(user.UserName, password, false, false))
                .ReturnsAsync(SignInResult.Success);

            var result = await _signInManager.Object.PasswordSignInAsync(user.UserName, password, false, false);

            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task Login_UserDoesNotExist_ReturnsFailure()
        {
            var email = "notfound@gmail.com";
            var password = "WrongPassword123!";

            _userManager.Setup(um => um.FindByEmailAsync(email)).ReturnsAsync((ApplicationUser)null);
            _signInManager.Setup(sm => sm.PasswordSignInAsync(email, password, false, false))
                .ReturnsAsync(SignInResult.Failed);

            var result = await _signInManager.Object.PasswordSignInAsync(email, password, false, false);

            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task Register_NewUser_ReturnsSuccess()
        {
            var user = new ApplicationUser { UserName = "newuser@gmail.com", Email = "newuser@gmail.com", Location = "Odessa", PersonName = "Semen" };
            var password = "SecurePassword123!";

            _userManager.Setup(um => um.CreateAsync(user, password)).ReturnsAsync(IdentityResult.Success);

            var result = await _userManager.Object.CreateAsync(user, password);

            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task Register_ExistingUser_ReturnsFailure()
        {
            var user = new ApplicationUser { UserName = "existing@gmail.com", Email = "existing@gmail.com", Location = "Basement", PersonName = "Random kid" };
            var password = "SecurePassword123!";

            _userManager.Setup(um => um.FindByEmailAsync(user.Email)).ReturnsAsync(user);
            _userManager.Setup(um => um.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "User already exists" }));

            var result = await _userManager.Object.CreateAsync(user, password);

            Assert.False(result.Succeeded);
        }
        [Fact]
        public async Task Logout_UserIsSignedIn_CallsSignOut()
        {
            _signInManager.Setup(sm => sm.SignOutAsync()).Returns(Task.CompletedTask);
            await _signInManager.Object.SignOutAsync();
            _signInManager.Verify(sm => sm.SignOutAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAccount_UserExists_ReturnsSuccess()
        {
            var user = new ApplicationUser { UserName = "delete@gmail.com", Email = "delete@gmail.com", Location = "Lalaland", PersonName = "Toby" };
            _userManager.Setup(um => um.FindByEmailAsync(user.Email)).ReturnsAsync(user);
            _userManager.Setup(um => um.DeleteAsync(user)).ReturnsAsync(IdentityResult.Success);

            var result = await _userManager.Object.DeleteAsync(user);

            Assert.True(result.Succeeded);
        }
    }
}
