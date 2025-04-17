using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Domain.Enums;
using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CozyHouse.Core.Services
{
    public class UserAdoptionRequestService : IUserAdoptionRequestService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserPetPublicationService _publicationService;
        private readonly IUserAdoptionRequestRepository _requestRepository;
        public UserAdoptionRequestService(UserManager<ApplicationUser> userManager, IUserPetPublicationService publicationRepository, IUserAdoptionRequestRepository requestRepository)
        {
            _userManager = userManager;
            _publicationService = publicationRepository;
            _requestRepository = requestRepository;
        }
        public async Task<bool> CreateAsync(Guid publicationId, Guid adopterId, Guid ownerId)
        {
            ApplicationUser? userFromDb = await _userManager.FindByIdAsync(adopterId.ToString());
            if (userFromDb == null) return false;

            UserPetPublication? publicationFromDb = _publicationService.Get(publicationId);
            if (publicationFromDb == null) return false;

            _requestRepository.Create(new UserAdoptionRequest()
            {
                PetPublicationId = publicationId,
                AdopterId = adopterId,
                OwnerId = ownerId,
            });
            return true;
        }
        
        public bool Approve(Guid requestId)
        {
            UserAdoptionRequest? request = _requestRepository.Read(requestId);
            if (request == null) return false;

            request.ApprovedDate = DateTime.UtcNow;
            request.Status = AdoptionStatus.Approved;
            //_publicationService.Delete(request.PetPublicationId);
            _requestRepository.Delete(requestId);
            return true;
        }
        
        public bool Reject(Guid requestId)
        {
            UserAdoptionRequest? request = _requestRepository.Read(requestId);
            if (request == null) return false;

            request.RejectedDate = DateTime.UtcNow;
            request.Status = AdoptionStatus.Rejected;
            //_publicationService.Delete(request.PetPublicationId);
            _requestRepository.Delete(request.Id);
            return true;
        }

        public IEnumerable<UserAdoptionRequest> GetAll()
        {
            return _requestRepository.GetAll();
        }

        public UserAdoptionRequest Get(Guid requestId)
        {
            return _requestRepository.Read(requestId);
        }
    }
}
