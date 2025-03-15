using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Domain.Enums;

namespace CozyHouse.Infrastructure.Helpers
{
    public static class PetStorage
    {
        private static List<Pet>? pets;
        public static List<Pet> Pets
        {
            get
            {
                if (pets == null)
                {
                    pets = new List<Pet>()
                    {
                        new Pet() {Id = Guid.Parse("7FB0100F-6B8B-4D1A-8013-B137B7F4B1DC"), Name = "Boss", Type = PetType.Parrot, Age = 2},
                        new Pet() {Id = Guid.Parse("6FB0100F-6B8B-4D1A-8013-B137B7F4B1DC"), Name = "Baby", Type = PetType.Dog, Age = 3},
                        new Pet() {Id = Guid.Parse("5FB0100F-6B8B-4D1A-8013-B137B7F4B1DC"), Name = "Monster", Type = PetType.Cat, Age = 1},
                    };
                }
                return pets;
            }
        }
    }
}
