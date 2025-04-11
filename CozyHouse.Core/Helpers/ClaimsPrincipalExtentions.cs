using System.Security.Claims;

namespace CozyHouse.Core.Helpers
{
    public static class ClaimsPrincipalExtentions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) throw new InvalidOperationException("User ID not found.");
            return Guid.Parse(userIdClaim.Value);
        }
    }
}
