using CozyHouse.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Core.Domain.Entities
{
    public class Pet
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Your pet needs a name")]
        public string Name { get; set; } = null!;
        public PetType Type { get; set; }
        public uint Age { get; set; }
        string? ImagePath { get; set; }
    }
}
