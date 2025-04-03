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
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public AuthorizationTests()
        {
            // Set up mock database context
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().Options;
            var dbContextMock = new DbContextMock<ApplicationDbContext>(options);
            var context = dbContextMock.Object;

            // Create test users
            var users = new List<ApplicationUser>
        {
            new ApplicationUser
            {
                Id = Guid.Parse("821C4C30-23F9-4E2C-A545-17E52726731A"),
                Age = 20,
                Email = "test@gmail.com",
                PersonName = "Bob",
                PhoneNumber = "+380372194495",
                Location = "New York",
                UserName = "test@gmail.com",
            }
        };

            dbContextMock.CreateDbSetMock(db => db.Users, users);

            // Mock dependencies for UserManager and SignInManager
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userManager = new UserManager<ApplicationUser>(userStoreMock.Object, null, null, null, null, null, null, null, null);

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var userPrincipalFactoryMock = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();
            
            _signInManager = new SignInManager<ApplicationUser>(_userManager, httpContextAccessorMock.Object,
                userPrincipalFactoryMock.Object, null, null, null, null);
        }
    }
}
