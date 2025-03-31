using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CozyHouse.Core.Domain.Entities.BaseEntities;

namespace CozyHouse.Core.Domain.Entities
{
    public class PetImage
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public required string ImageUrl { get; set; }

        [Required]
        [ForeignKey(nameof(PetPublication))]
        public Guid PetPublicationId { get; set; }
        public virtual PetPublicationBase PetPublication { get; set; } = null!;
    }
}
