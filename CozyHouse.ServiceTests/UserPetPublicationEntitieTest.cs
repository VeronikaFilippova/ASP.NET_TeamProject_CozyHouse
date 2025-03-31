using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreMock;
using CozyHouse.Infrastructure.Repositories;
using CozyHouse.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.CoreTests
{
    public class UserPetPublicationEntitieTest
    {
        private DbContextMock<ApplicationDbContext> _dbContextMock;
        private DbSetMock<UserPetPublication> _userPetPublicationsMock;

        public void Setup()
        {
            _dbContextMock = new DbContextMock<ApplicationDbContext>();
            _userPetPublicationsMock = _dbContextMock.CreateDbSetMock(x => x.UserPetPublications, new List<UserPetPublication>());
        }

        public void CreateUserPetPublication_ShouldAddPublication()
        {
            var publication = new UserPetPublication
            {
                Id = Guid.NewGuid(),
                OwnerId = Guid.NewGuid(),
                Description = "Test Description",
                IsSterilized = false,
                IsVaccinated = false,
                Location = "Unknown",
                PetName = "Buddy",
                PublicationTitle = "Adopt a Cute Dog",
                Summary = "A friendly and loving dog looking for a new home."
            };

            _userPetPublicationsMock.Object.Add(publication);
            _dbContextMock.Object.SaveChanges();
        }
    }
}