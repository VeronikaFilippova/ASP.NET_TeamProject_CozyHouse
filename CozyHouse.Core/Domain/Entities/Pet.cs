using CozyHouse.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Core.Domain.Entities
{
    public class Pet
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public uint Age { get; set; }
    }
}
