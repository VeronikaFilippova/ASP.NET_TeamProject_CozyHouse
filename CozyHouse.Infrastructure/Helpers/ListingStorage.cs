using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Infrastructure.Helpers
{
    public static class ListingStorage
    {
        private static List<Listing>? listings;
        public static List<Listing> Listings 
        {
            get
            {
                if (listings == null)
                {
                    listings = new List<Listing>()
                    {
                        new Listing() {Id = Guid.Parse("7FB0100F-6B8B-4D1A-8013-B137B7F4B1DC"), Title = "Gym", Content = "Go to the gym", Topic = "Fitness", Rating = 10 },
                        new Listing() {Id = Guid.Parse("6FB0100F-6B8B-4D1A-8013-B137B7F4B1DC"), Title = "Best Protein Dish in 5 minutes", Content = "Joke! Ha", Topic = "Cooking", Rating = 8 },
                        new Listing() {Id = Guid.Parse("5FB0100F-6B8B-4D1A-8013-B137B7F4B1DC"), Title = "Books to Read", Content = "Atomic Habits and so on", Topic = "Reading", Rating = 9 },
                    };
                }
                return listings;
            }
        }
    }
}
