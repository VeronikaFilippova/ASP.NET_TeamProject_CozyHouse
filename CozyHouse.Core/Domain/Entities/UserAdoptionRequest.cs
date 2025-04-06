using CozyHouse.Core.Domain.Entities.BaseEntities;
using CozyHouse.Core.Domain.IdentityEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozyHouse.Core.Domain.Entities
{
    public class UserAdoptionRequest : AdoptionRequestBase
    {
        [ForeignKey(nameof(Adopter))]
        public Guid AdopterId { get; set; }
        public ApplicationUser Adopter { get; set; } = null!;

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public ApplicationUser Owner { get; set; } = null!;

        [ForeignKey(nameof(PetPublication))]
        public Guid PetPublicationId { get; set; }
        public UserPetPublication PetPublication { get; set; } = null!;
    }
}
