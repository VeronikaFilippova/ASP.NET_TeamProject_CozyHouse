using CozyHouse.Core.Domain.IdentityEntities;

namespace CozyHouse.UI.DTO
{
    public class UserManagerViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<ApplicationUser> Managers { get; set; }
    }
}
