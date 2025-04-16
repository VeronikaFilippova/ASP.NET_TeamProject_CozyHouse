using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.UI.DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string? UserEmail { get; set; }

        [Required]
        [DisplayName("Password")]
        public string? UserPassword { get; set; }
    }
}
