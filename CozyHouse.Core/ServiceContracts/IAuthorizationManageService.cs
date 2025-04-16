using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.Helpers;
using Microsoft.AspNetCore.Identity;

namespace CozyHouse.Core.ServiceContracts
{
    /// <summary>
    /// Encapsulates authentication and user validation logic to simplify controller implementation and improve readability.
    /// </summary>
    public interface IAuthorizationManageService
    {
        /// <summary>
        /// Attempts to log in a user using the specified username and password.
        /// </summary>
        /// <param name="username">The username of the user attempting to log in.</param>
        /// <param name="password">The corresponding password.</param>
        /// <returns>
        /// An <see cref="ExtendedSignInResult"/> containing the sign-in result and an optional error message.
        /// </returns>
        Task<ExtendedSignInResult> LoginAsync(string username, string password);
        
        /// <summary>
        /// Logs out the currently authenticated user.
        /// </summary>
        Task LogoutAsync();

        /// <summary>
        /// Registers a new user with the specified password and assigns them to a given role.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <param name="password">The password for the user.</param>
        /// <param name="role">The role to assign to the user.</param>
        /// <returns>An <see cref="IdentityResult"/> indicating the outcome of the registration.</returns>
        Task<IdentityResult> RegisterWithRoleAsync(ApplicationUser user, string password, string role);

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>The <see cref="ApplicationUser"/> corresponding to the specified ID.</returns>
        Task<ApplicationUser> GetUserAsync(Guid userId);

        /// <summary>
        /// Deletes the user with the specified unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>An <see cref="IdentityResult"/> indicating the outcome of the deletion operation.</returns>
        Task<IdentityResult> DeleteAsync(Guid userId);
    }
}
