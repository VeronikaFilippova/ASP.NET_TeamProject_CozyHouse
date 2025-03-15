using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Core.Domain.Entities
{
    public class Listing
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title can't be null")]
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImagePath { get; set; }

        public Pet? Pet { get; set; }
    }
}
