using CozyHouse.Core.Domain.IdentityEntities;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Core.Domain.Entities
{
    public class UserRequest : Request
    {
        [Required]
        public ApplicationUser? PetOwner { get; set; }
    }
}
