using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;

namespace CozyHouse.Core.Services
{
    public class UserStatsService : IUserStatsService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserStatsService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> IncreasePetsAdoptedCounterAsync(Guid userId, uint amount)
        {
            ApplicationUser? currentUser = await _userManager.FindByIdAsync(userId.ToString());
            if (currentUser == null) return false;

            currentUser.PetsAdopted += amount;
            await _userManager.UpdateAsync(currentUser);
            return true;
        }
        public async Task<bool> DecreasePetsAdoptedCounterAsync(Guid userId, uint amount)
        {
            ApplicationUser? currentUser = await _userManager.FindByIdAsync(userId.ToString());
            if (currentUser == null) return false;
            if (currentUser.PetsAdopted < amount) throw new ArgumentException("Amount is greater than PetsAdopted");

            currentUser.PetsAdopted -= amount;
            await _userManager.UpdateAsync(currentUser);
            return true;
        }

        public async Task<bool> IncreasePublicationsCreatedCounterAsync(Guid userId, uint amount)
        {
            ApplicationUser? currentUser = await _userManager.FindByIdAsync(userId.ToString());
            if (currentUser == null) return false;

            currentUser.PublicationsCreated += amount;
            await _userManager.UpdateAsync(currentUser);
            return true;
        }

        public async Task<bool> DecreasePublicationsCreatedCounterAsync(Guid userId, uint amount)
        {
            ApplicationUser? currentUser = await _userManager.FindByIdAsync(userId.ToString());
            if (currentUser == null) return false;
            if (currentUser.PublicationsCreated < amount) throw new ArgumentException("Amount is greater than PublicationsCreated");

            currentUser.PublicationsCreated -= amount;
            await _userManager.UpdateAsync(currentUser);
            return true;
        }
    }
}
