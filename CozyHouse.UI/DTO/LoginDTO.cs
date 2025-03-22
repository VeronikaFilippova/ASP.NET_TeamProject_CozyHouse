using System.ComponentModel.DataAnnotations;

namespace CozyHouse.UI.DTO
{
    public class LoginDTO
    {
        public string? UserLogin { get; set; }
        public string? UserPassword { get; set; }
        public string PhoneNumber { get; set; }
    }
}
