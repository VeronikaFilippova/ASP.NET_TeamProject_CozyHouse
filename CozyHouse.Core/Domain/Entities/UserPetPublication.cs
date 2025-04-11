using CozyHouse.Core.Domain.Entities.BaseEntities;
using CozyHouse.Core.Domain.IdentityEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozyHouse.Core.Domain.Entities
{
    public class UserPetPublication : PetPublicationBase
    {
        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; } = null!;
    }
}
