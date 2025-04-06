using CozyHouse.Core.Domain.Entities.BaseEntities;
using CozyHouse.Core.Domain.IdentityEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozyHouse.Core.Domain.Entities
{
    public class ShelterAdoptionRequest : AdoptionRequestBase
    {
        [ForeignKey(nameof(Adopter))]
        public Guid AdopterId { get; set; }
        public ApplicationUser Adopter { get; set; } = null!;

        [ForeignKey(nameof(PetPublication))]
        public Guid PetPublicationId { get; set; }
        public ShelterPetPublication PetPublication { get; set; } = null!;
    }
}
