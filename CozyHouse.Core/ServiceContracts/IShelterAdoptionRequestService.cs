using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.ServiceContracts
{
    public interface IShelterAdoptionRequestService
    {
        Task<bool> CreateRequestAsync(Guid publicationId, Guid adopterId);
        bool ApproveRequest(Guid requestId);
        bool RejectRequest(Guid requestId);
        IEnumerable<ShelterAdoptionRequest> GetAllRequests();
    }
}
