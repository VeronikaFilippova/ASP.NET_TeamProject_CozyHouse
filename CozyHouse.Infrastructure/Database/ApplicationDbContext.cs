using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CozyHouse.Infrastructure.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options): base(options) {}

        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Listing> Listings { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<UserPet> UserPets { get; set; }
        public virtual DbSet<UserListing> UserListings { get; set; }
        public virtual DbSet<UserRequest> UserRequests { get; set; }
    }
}
