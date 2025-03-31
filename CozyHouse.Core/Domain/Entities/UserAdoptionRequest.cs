using CozyHouse.Core.Domain.Entities.BaseEntities;
using CozyHouse.Core.Domain.IdentityEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Core.Domain.Entities
{
    public class UserAdoptionRequest : AdoptionRequestBase
    {
        [Required]
        [ForeignKey(nameof(Adopter))]
        public Guid AdopterId { get; set; }
        public ApplicationUser Adopter { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public ApplicationUser Owner { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(PetPublication))]
        public Guid PetPublicationId { get; set; }
        public UserPetPublication PetPublication { get; set; } = null!;

    }
}
