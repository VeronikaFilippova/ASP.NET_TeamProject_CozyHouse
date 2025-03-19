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

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Listing))]
        public Guid ListingId { get; set; }

        [Required]
        public ApplicationUser? User { get; set; }
        
        [Required]
        public Listing? Listing { get; set; }
    }
}
