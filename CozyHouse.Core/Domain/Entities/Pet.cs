using CozyHouse.Core.Domain.Enums;

namespace CozyHouse.Core.Domain.Entities
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public uint Age { get; set; }

        public override string ToString()
        {
            return $"{Name} is {Age} years old, and is a {nameof(Type)}";
        }

    }
}
