using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreMock;
using CozyHouse.Infrastructure.Repositories;
using CozyHouse.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace CozyHouse.CoreTests.EntitieTests
{
    public class UserAdoptionRequestEntitieTest
    {
        private readonly DbContextMock<ApplicationDbContext> _dbContextMock;
        private readonly ApplicationDbContext _dbContext;

        public UserAdoptionRequestEntitieTest()
        {
            _dbContextMock = new DbContextMock<ApplicationDbContext>(
                new DbContextOptionsBuilder<ApplicationDbContext>().Options
            );
            _dbContext = _dbContextMock.Object;
            _dbContextMock.CreateDbSetMock(x => x.UserAdoptionRequests, new List<UserAdoptionRequest>());
        }

        [Fact]
        public void UserAdoptionRequest_Should_Fail_Validation_If_Required_Fields_Are_Empty()
        {
            var request = new UserAdoptionRequest
            {
                AdopterId = Guid.Empty,
                OwnerId = Guid.Empty,
                PetPublicationId = Guid.Empty
            };

            Assert.True(request.AdopterId == Guid.Empty, "AdopterId має бути заповненим");
            Assert.True(request.OwnerId == Guid.Empty, "OwnerId має бути заповненим");
            Assert.True(request.PetPublicationId == Guid.Empty, "PetPublicationId має бути заповненим");
        }

        [Fact]
        public void Can_Add_UserAdoptionRequest_To_Database()
        {
            var request = new UserAdoptionRequest
            {
                Id = Guid.NewGuid(),
                AdopterId = Guid.NewGuid(),
                OwnerId = Guid.NewGuid(),
                PetPublicationId = Guid.NewGuid(),
            };

            _dbContext.UserAdoptionRequests.Add(request);
            _dbContext.SaveChanges();

            Assert.Contains(_dbContext.UserAdoptionRequests, r => r.Id == request.Id);
        }
    }
}