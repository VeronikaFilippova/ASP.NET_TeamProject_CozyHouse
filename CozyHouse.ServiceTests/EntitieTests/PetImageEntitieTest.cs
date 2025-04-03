using CozyHouse.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit;

namespace CozyHouse.CoreTests.EntitieTests
{
    public class PetImageTests
    {
        [Fact]
        public void PetImage_ValidData_PassesValidation()
        {
            PetImage image = new PetImage
            {
                Id = Guid.NewGuid(),
                ImageUrl = "https://example.com/pet-image.jpg",
                PetPublicationId = Guid.NewGuid()
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(image,
                new ValidationContext(image),
                validationResults,
                validateAllProperties: true);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void PetImage_EmptyImageUrl_FailsValidation()
        {
            PetImage image = new PetImage
            {
                Id = Guid.NewGuid(),
                ImageUrl = "",
                PetPublicationId = Guid.NewGuid()
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(image,
                new ValidationContext(image),
                validationResults,
                validateAllProperties: true);

            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.MemberNames.Contains(nameof(PetImage.ImageUrl)));
        }


        [Fact]
        public void PetImage_HasKeyAttribute()
        {
            var idProperty = typeof(PetImage).GetProperty(nameof(PetImage.Id));

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), false);

            Assert.NotEmpty(keyAttribute);
        }

        [Fact]
        public void PetImage_HasRequiredAttributes()
        {
            var imageUrlProperty = typeof(PetImage).GetProperty(nameof(PetImage.ImageUrl));
            var petPublicationIdProperty = typeof(PetImage).GetProperty(nameof(PetImage.PetPublicationId));

            var imageUrlRequiredAttribute = imageUrlProperty.GetCustomAttributes(typeof(RequiredAttribute), false);
            var petPublicationIdRequiredAttribute = petPublicationIdProperty.GetCustomAttributes(typeof(RequiredAttribute), false);

            Assert.NotEmpty(imageUrlRequiredAttribute);
            Assert.NotEmpty(petPublicationIdRequiredAttribute);
        }

        [Fact]
        public void PetImage_PetPublicationId_HasForeignKeyAttribute()
        {
            var petPublicationIdProperty = typeof(PetImage).GetProperty(nameof(PetImage.PetPublicationId));

            var foreignKeyAttribute = petPublicationIdProperty.GetCustomAttributes(typeof(ForeignKeyAttribute), false) as ForeignKeyAttribute[];

            Assert.NotEmpty(foreignKeyAttribute);
            Assert.Equal(nameof(PetImage.PetPublication), foreignKeyAttribute[0].Name);
        }

        [Fact]
        public void PetImage_PetPublication_Reference_Initialized()
        {
            var petImage = new PetImage
            {
                Id = Guid.NewGuid(),
                ImageUrl = "https://example.com/pet-image.jpg",
                PetPublicationId = Guid.NewGuid()
            };

            Assert.Null(petImage.PetPublication);
        }
    }
}