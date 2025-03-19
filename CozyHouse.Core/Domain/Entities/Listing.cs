using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozyHouse.Core.Domain.Entities
{
    public class Listing
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title can't be null")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Content can't be null")]
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(Pet))]
        public Guid PetId { get; set; }

        public Pet Pet { get; set; } = null!;
    }
}
