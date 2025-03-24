using System.ComponentModel.DataAnnotations;

namespace CozyHouse.UI.DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string? UserEmail { get; set; }

        [Required]
        public string? UserPassword { get; set; }
    }
}
