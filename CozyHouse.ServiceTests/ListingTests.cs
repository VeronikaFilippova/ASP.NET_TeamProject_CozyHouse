using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Services;
using CozyHouse.Infrastructure.Repositories;

namespace CozyHouse.ServiceTests
{
    public class ListingTests
    {
        ListingService listingService;
        public ListingTests()
        {
            listingService = new ListingService(new FakeDbListingRepository());
        }
        [Fact]
        public void GetListing_RightArguments_ToBeSuccessful()
        {
            Listing listing = listingService.GetListing(Guid.Parse("7FB0100F-6B8B-4D1A-8013-B137B7F4B1DC"))!;
            Assert.Equal("Gym", listing.Title);
        }
    }
}