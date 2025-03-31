using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CozyHouse.Core.Domain.Enums;

namespace CozyHouse.Core.Domain.Entities.BaseEntities
{
    public abstract class PetPublicationBase
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Publication Title")]
        public required string PublicationTitle { get; set; }
        [Required]
        public required string Summary { get; set; } // Короткий, захоплюючий опис про тварину
        public string? Description { get; set; } // Більш детальний опис тварини
        [Required]
        public DateTime PublishedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public required string Location { get; set; } // Розташування тварини


        [Required]
        public required string PetName { get; set; }
        [Required]
        public double PetAge { get; set; }
        [Required]
        public Species PetType { get; set; } // Dog, Cat, ...
        public string? Breed { get; set; } // Labrador, Maine coon, ...
        [Required]
        public required bool IsVaccinated { get; set; }
        [Required]
        public required bool IsSterilized { get; set; }
        public bool IsAdopted { get; set; } = false;


        public virtual List<PetImage> Images { get; set; } = new();
    }
}
