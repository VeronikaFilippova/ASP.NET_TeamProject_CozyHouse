using CozyHouse.Core.Domain.Entities.BaseEntities;
using CozyHouse.Core.Domain.IdentityEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozyHouse.Core.Domain.Entities
{
    public class ShelterAdoptionRequest : AdoptionRequestBase
    {
        [Required]
        [ForeignKey(nameof(Adopter))]
        public Guid AdopterId { get; set; }
        public ApplicationUser Adopter { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(PetPublication))]
        public Guid PetPublicationId { get; set; }
        public ShelterPetPublication PetPublication { get; set; } = null!;
    }
}
