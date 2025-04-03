using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreMock;
using CozyHouse.Infrastructure.Repositories;
using CozyHouse.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.CoreTests.RepositoryTests
{
    public class UserAdoptionRequestRepositoryTests
    {
        private readonly UserAdoptionRequestRepository _repository;

        public UserAdoptionRequestRepositoryTests()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder<ApplicationDbContext>();
            DbContextMock<ApplicationDbContext> dbContextMock = new DbContextMock<ApplicationDbContext>(options.Options);

            ApplicationDbContext context = dbContextMock.Object;

            List<UserAdoptionRequest> requests = new List<UserAdoptionRequest>
            {
                new UserAdoptionRequest
                {
                    Id = Guid.Parse("12345678-1234-1234-1234-123456789012"),
                    AdopterId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    PetPublicationId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                }
            };

            dbContextMock.CreateDbSetMock(db => db.UserAdoptionRequests, requests);

            _repository = new UserAdoptionRequestRepository(context);
        }

        #region Create
        [Fact]
        public void Create_ValidRequest_ShouldBeSuccessful()
        {
            UserAdoptionRequest request = new UserAdoptionRequest
            {
                Id = Guid.NewGuid(),
                AdopterId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                PetPublicationId = Guid.Parse("00000000-0000-0000-0000-000000000006")
            };

            _repository.Create(request);

            Assert.Equal(2, _repository.GetAll().Count());
        }

        [Fact]
        public void Create_InvalidRequest_ShouldThrowValidationException()
        {
            Assert.Throws<FormatException>(() =>
            {
                UserAdoptionRequest request = new UserAdoptionRequest
                {
                    Id = Guid.Parse(""),
                    AdopterId = Guid.Empty,
                    OwnerId = Guid.Empty,
                    PetPublicationId = Guid.Empty
                };
                _repository.Create(request);
            });
        }
        #endregion

        #region Read
        [Fact]
        public void Read_ValidId_ShouldReturnRequest()
        {
            var result = _repository.Read(Guid.Parse("12345678-1234-1234-1234-123456789012"));
            Assert.NotNull(result);
        }

        [Fact]
        public void Read_InvalidId_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _repository.Read(Guid.NewGuid()));
        }
        #endregion

        #region Update
        [Fact]
        public void Update_ValidRequest_ShouldBeSuccessful()
        {
            UserAdoptionRequest request = _repository.Read(Guid.Parse("12345678-1234-1234-1234-123456789012"));
            request.AdopterId = Guid.Parse("00000000-0000-0000-0000-000000000007");

            _repository.Update(request);

            UserAdoptionRequest updatedRequest = _repository.Read(Guid.Parse("12345678-1234-1234-1234-123456789012"));
            Assert.Equal(Guid.Parse("00000000-0000-0000-0000-000000000007"), updatedRequest.AdopterId);
        }

        [Fact]
        public void Update_InvalidRequest_ShouldThrowValidationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                UserAdoptionRequest request = _repository.Read(Guid.Parse("12345678-1234-1234-1234-123456719312"));
                request.OwnerId = Guid.Empty;
                _repository.Update(request);
            });
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete_ValidId_ShouldRemoveRequest()
        {
            _repository.Delete(Guid.Parse("12345678-1234-1234-1234-123456789012"));
            Assert.Empty(_repository.GetAll());
        }

        [Fact]
        public void Delete_InvalidId_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _repository.Delete(Guid.NewGuid()));
        }
        #endregion

        #region GetAll
        [Fact]
        public void GetAll_ShouldReturnSingleRequest()
        {
            var requests = _repository.GetAll();
            Assert.Single(requests);
        }
        #endregion
    }
}
