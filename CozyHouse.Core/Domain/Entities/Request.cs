using CozyHouse.Core.Domain.IdentityEntities;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Core.Domain.Entities
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsClosed { get; set; }

        [Required]
        public ApplicationUser? User { get; set; }
        
        [Required]
        public Listing? Listing { get; set; }
    }
}
