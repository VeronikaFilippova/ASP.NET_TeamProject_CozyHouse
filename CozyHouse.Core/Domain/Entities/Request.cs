using CozyHouse.Core.Domain.IdentityEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozyHouse.Core.Domain.Entities
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsClosed { get; set; }


        [ForeignKey(nameof(Adopter))]
        public Guid AdopterId { get; set; }
        public ApplicationUser? Adopter { get; set; }


        [ForeignKey(nameof(Listing))]
        public Guid ListingId { get; set; }
        public Listing? Listing { get; set; }
    }
}
