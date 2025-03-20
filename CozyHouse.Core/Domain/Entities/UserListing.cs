using CozyHouse.Core.Domain.IdentityEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozyHouse.Core.Domain.Entities
{
    public class UserListing
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title can't be null")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Content can't be null")]
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public ApplicationUser Owner { get; set; } = null!;

        [ForeignKey(nameof(Pet))]
        public Guid PetId { get; set; }
        public UserPet Pet { get; set; } = null!;
    }
}
