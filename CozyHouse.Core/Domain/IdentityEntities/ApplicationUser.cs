using Microsoft.AspNetCore.Identity;
using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? PersonName { get; set; }
    }
}
