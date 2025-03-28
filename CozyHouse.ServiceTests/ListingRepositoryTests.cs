using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Core.Domain.Enums;
using CozyHouse.Infrastructure.Repositories;
using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreMock;

namespace CozyHouse.CoreTests
{
    public class ListingRepositoryTests
    {
        private readonly IListingRepository _listingRepository;
        public ListingRepositoryTests()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder<ApplicationDbContext>(); // Будує параметри для створення контексту бази даних
            DbContextMock<ApplicationDbContext> dbContextMock = 
                new DbContextMock<ApplicationDbContext>(options.Options); // Створює мок-об'єкт для ApplicationDbContext (імітація бази даних)

            ApplicationDbContext context = dbContextMock.Object; // Отримуємо об'єкт імітованого контексту бази даних

            List<Listing> listingsInitialData = new List<Listing>() // Початковий набір даних для імітації таблиці Listings
            {
                new Listing()
                {
                    Id = Guid.Parse("5523F9E5-7C5A-4FA0-B861-3C6B4F8E08CD"),
                    Title = "Listing 1",
                    Content = "Content",
                    Pet = new Pet() { Id = Guid.Parse("C65D9703-01F9-43BE-9A9E-A4E348B2C996"), Name = "Test Pet", Age = 1, Type = PetType.Cat },
                    PetId = Guid.Parse("C65D9703-01F9-43BE-9A9E-A4E348B2C996")
                }
            }; 
            dbContextMock.CreateDbSetMock(db => db.Listings, listingsInitialData); // Створюємо імітований DbSet<Listing> із початковими даними

            _listingRepository = new ListingRepository(context); // Ініціалізуємо репозиторій, використовуючи імітований контекст

        }

        #region Add
        [Fact]
        public void Add_RightArugments_ToBeSuccessful()
        {
            Listing listing = new Listing()
            {
                Title = "Test Title",
                Content = "Test Content",
                Pet = new Pet() { Name = "Test Pet", Age = 2, Type = PetType.Hamster }
            };

            bool result = _listingRepository.Add(listing);
            Assert.True(result);
        }
        [Fact]
        public void Add_WrongArugments_ToBeFailure()
        {
            Listing listing = new Listing()
            {
                Title = null,
                Content = null,
            };

            bool result = _listingRepository.Add(listing);
            Assert.False(result);
        }
        #endregion

        #region Get
        [Fact]
        public void GetListing_RightArguments_ToBeNotNull()
        {
            Assert.NotNull(_listingRepository.GetListing(Guid.Parse("5523F9E5-7C5A-4FA0-B861-3C6B4F8E08CD")));
        }

        [Fact]
        public void GetListing_WrongArguments_ToBeNull()
        {
            Assert.Null(_listingRepository.GetListing(Guid.Parse("8A3DCAFC-7421-4B6E-B593-A9E1833BE9B3")));
        }

        [Fact]
        public void GetAll_ToBeEqual1()
        {
            Assert.Single(_listingRepository.GetAll());
        }

        [Fact]
        public void GetByPetType_ToBeEqual1()
        {
            Assert.Single(_listingRepository.GetByPetType(PetType.Cat));
        }
        [Fact]
        public void GetByPetType_ToBeEqual0()
        {
            Assert.Empty(_listingRepository.GetByPetType(PetType.Dog));
        }

        [Fact]
        public void GetByTitle_RightArguments_ToBeNotNull()
        {
            Assert.NotNull(_listingRepository.GetByTitle("Listing 1"));
        }
        [Fact]
        public void GetByTitle_WtongArguments_ToBeNull()
        {
            Assert.NotNull(_listingRepository.GetByTitle("Not Real Title"));
        }
        #endregion

        #region Update
        [Fact]
        public void Update_RightArguments_ToBeSuccessful()
        {
            Listing listingFromDb = _listingRepository.GetListing(Guid.Parse("5523F9E5-7C5A-4FA0-B861-3C6B4F8E08CD"))!;
            listingFromDb.Title = "New Title";

            Listing? updatedListing = _listingRepository.Update(listingFromDb);
            Assert.Equal("New Title", updatedListing?.Title);
        }

        [Fact]
        public void Update_WrongArguments_ToBeFailure()
        {
            Listing listingFromDb = _listingRepository.GetListing(Guid.Parse("5523F9E5-7C5A-4FA0-B861-3C6B4F8E08CD"))!;
            listingFromDb.Title = null;
            listingFromDb.Content = null;

            Listing? updatedListing = _listingRepository.Update(listingFromDb);
            Assert.Null(updatedListing);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete_RightArguments_ToBeSuccessful()
        {
            bool result = _listingRepository.Delete(Guid.Parse("5523F9E5-7C5A-4FA0-B861-3C6B4F8E08CD"));
            Assert.True(result);
        }

        [Fact]
        public void Delete_WrongArguments_ToBeFailure()
        {
            bool result = _listingRepository.Delete(Guid.Parse("5523F9E5-7C5A-4FA0-B861-366B4F8E08CD"));
            Assert.False(result);
        }
        #endregion
    }
}
