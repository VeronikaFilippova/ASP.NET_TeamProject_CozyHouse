using Microsoft.AspNetCore.Identity;
using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string PersonName { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
    }
}
