namespace CozyHouse.Core.ServiceContracts
{
    public interface IUserStatsService
    {
        Task<bool> IncreasePetsAdoptedCounterAsync(Guid userId, uint amount);
        Task<bool> DecreasePetsAdoptedCounterAsync(Guid userId, uint amount);
        Task<bool> IncreasePublicationsCreatedCounterAsync(Guid userId, uint amount);
        Task<bool> DecreasePublicationsCreatedCounterAsync(Guid userId, uint amount);
    }
}
