using CozyHouse.Core.Domain.Enums;
using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;

namespace CozyHouse.Core.Services
{
    public class ShelterAdoptionRequestService : IShelterAdoptionRequestService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IShelterPetPublicationService _publicationRepository;
        private readonly IShelterAdoptionRequestRepository _requestRepository;
        public ShelterAdoptionRequestService(UserManager<ApplicationUser> userManager, IShelterPetPublicationService publicationRepository, IShelterAdoptionRequestRepository requestRepository)
        {
            _userManager = userManager;
            _publicationRepository = publicationRepository;
            _requestRepository = requestRepository;
        }
        public async Task<bool> CreateRequestAsync(Guid publicationId, Guid adopterId)
        {
            ApplicationUser? userFromDb = await _userManager.FindByIdAsync(adopterId.ToString());
            if (userFromDb == null) return false;

            ShelterPetPublication? publicationFromDb = _publicationRepository.Get(publicationId);
            if (publicationFromDb == null) return false;

            _requestRepository.Create(new ShelterAdoptionRequest()
            {
                PetPublicationId = publicationId,
                AdopterId = adopterId,
            });
            return true;
        }

        public bool ApproveRequest(Guid requestId)
        {
            ShelterAdoptionRequest? request = _requestRepository.Read(requestId);
            if (request == null) return false;

            request.ApprovedDate = DateTime.UtcNow;
            request.Status = AdoptionStatus.Approved;
            //_publicationRepository.Delete(request.PetPublicationId);
            _requestRepository.Delete(requestId);
            return true;
        }

        public bool RejectRequest(Guid requestId)
        {
            ShelterAdoptionRequest? request = _requestRepository.Read(requestId);
            if (request == null) return false;

            request.RejectedDate = DateTime.UtcNow;
            request.Status = AdoptionStatus.Rejected;
            //_publicationRepository.Delete(request.PetPublicationId);
            _requestRepository.Delete(request.Id);
            return true;
        }

        public IEnumerable<ShelterAdoptionRequest> GetAllRequests()
        {
            return _requestRepository.GetAll();
        }
    }
}
