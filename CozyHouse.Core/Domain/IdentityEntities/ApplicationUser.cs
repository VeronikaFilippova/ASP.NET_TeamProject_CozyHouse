using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Core.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        public required string PersonName { get; set; }
        public int Age { get; set; }
        [Required]
        public required string Location { get; set; }
        public uint PetsAdopted { get; set; }
        public uint PublicationsCreated { get; set; }
    }
}
