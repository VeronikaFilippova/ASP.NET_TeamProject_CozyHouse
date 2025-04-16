using System.Security.Claims;

namespace CozyHouse.Core.Helpers
{
    /// <summary>
    /// Provides extension methods for working with <see cref="ClaimsPrincipal"/>, 
    /// offering common functionality not available by default.
    /// </summary>
    public static class ClaimsPrincipalExtentions
    {
        /// <summary>
        /// Retrieves the unique identifier (ID) of the currently authenticated user.
        /// </summary>
        /// <param name="user">The <see cref="ClaimsPrincipal"/> instance representing the current user.</param>
        /// <returns>The user's ID as a <see cref="Guid"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the user ID claim is not found (i.e., the user is not authenticated).</exception>
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) throw new InvalidOperationException("User ID not found.");
            return Guid.Parse(userIdClaim.Value);
        }
    }
}
