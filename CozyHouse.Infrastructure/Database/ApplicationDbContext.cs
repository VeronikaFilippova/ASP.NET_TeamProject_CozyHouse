using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CozyHouse.Infrastructure.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options): base(options) {}

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<UserPet> UserPets { get; set; }
        public DbSet<UserListing> UserListings { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
    }
}
