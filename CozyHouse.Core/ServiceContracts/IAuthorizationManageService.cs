using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.Helpers;
using Microsoft.AspNetCore.Identity;

namespace CozyHouse.Core.ServiceContracts
{
    public interface IAuthorizationManageService
    {
        Task<ExtendedSignInResult> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task<IdentityResult> RegisterWithRoleAsync(ApplicationUser user, string password, string role);
        Task<ApplicationUser> GetUserAsync(Guid userId);
        Task<IdentityResult> DeleteAsync(Guid userId);
    }
}
