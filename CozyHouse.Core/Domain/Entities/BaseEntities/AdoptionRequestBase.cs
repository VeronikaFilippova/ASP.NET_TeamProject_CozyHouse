using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CozyHouse.Core.Domain.Enums;

namespace CozyHouse.Core.Domain.Entities.BaseEntities
{
    public abstract class AdoptionRequestBase
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public string? Message { get; set; }
        [Required]
        public AdoptionStatus Status { get; set; } = AdoptionStatus.Pending;
        public DateTime? ApprovedDate { get; set; }
        public DateTime? RejectedDate { get; set; }
    }
}
