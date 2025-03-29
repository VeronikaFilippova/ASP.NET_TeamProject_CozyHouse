using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CozyHouse.Infrastructure.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options): base(options) {}

        public virtual DbSet<ShelterPetPublication> ShelterPetPublications { get; set; }
        public virtual DbSet<UserPetPublication> UserPetPublications { get; set; }
        public virtual DbSet<ShelterAdoptionRequest> ShelterAdoptionRequests { get; set; }
        public virtual DbSet<UserAdoptionRequest> UserAdoptionRequests { get; set; }
        public virtual DbSet<PetImage> PetImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserAdoptionRequest>().HasOne(r => r.Adopter).WithMany().HasForeignKey(r => r.AdopterId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<UserAdoptionRequest>().HasOne(r => r.Owner).WithMany().HasForeignKey(r => r.OwnerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
