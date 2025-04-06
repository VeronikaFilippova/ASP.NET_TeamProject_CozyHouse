using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.Extended_Classes;
using Microsoft.AspNetCore.Identity;

namespace CozyHouse.Core.ServiceContracts
{
    public interface IAuthorizationManageService
    {
        Task<ExtendedSignInResult> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task<IdentityResult> RegisterWithRoleAsync(ApplicationUser user, string password, string role);
        Task<IdentityResult> DeleteAsync(Guid userId);
    }
}
