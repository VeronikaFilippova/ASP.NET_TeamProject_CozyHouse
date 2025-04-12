using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Helpers;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Core.Services
{
    public class UserPetPublicationService : IUserPetPublicationService
    {
        private readonly IUserPetPublicationRepository _userPublicationRepository;
        private readonly IPetImageRepository _petImageRepository;
        private readonly IPublicationImageHelper _imageSaveHelper;
        public UserPetPublicationService(IUserPetPublicationRepository publicationRepository, IPetImageRepository imageRepository, IPublicationImageHelper helper)
        {
            _userPublicationRepository = publicationRepository;
            _petImageRepository = imageRepository;
            _imageSaveHelper = helper;
        }
        public bool Add(UserPetPublication publication, IFormFile[] files)
        {
            bool isValid = Validator.TryValidateObject(publication, new ValidationContext(publication), null);
            if (isValid == false) return false;

            _userPublicationRepository.Create(publication);
            foreach (IFormFile file in files)
            {
                string filePath = _imageSaveHelper.SaveImage(file);
                PetImage image = new PetImage() { ImageUrl = filePath, PetPublicationId = publication.Id };
                _petImageRepository.Create(image);
            }
            return true;
        }

        public UserPetPublication? Get(Guid publicationId)
        {
            return _userPublicationRepository.Read(publicationId);
        }

        public bool Update(UserPetPublication publication)
        {
            bool isValid = Validator.TryValidateObject(publication, new ValidationContext(publication), null);
            if (isValid == false) return false;
            _userPublicationRepository.Update(publication);
            return true;
        }

        public bool Delete(Guid id)
        {
            UserPetPublication? publication = _userPublicationRepository.Read(id);
            if (publication == null) return false;

            foreach (PetImage image in publication.Images)
            {
                _imageSaveHelper.DeleteImage(image.ImageUrl);
            }
            _userPublicationRepository.Delete(id);
            return true;
        }

        public bool AddImage(Guid publicationId, IFormFile file)
        {
            UserPetPublication? publication = _userPublicationRepository.Read(publicationId);
            if (publication == null) return false;

            string filePath = _imageSaveHelper.SaveImage(file);
            PetImage image = new PetImage() { ImageUrl = filePath, PetPublicationId = publicationId };
            _petImageRepository.Create(image);
            return false;
        }

        public bool DeleteImage(Guid imageId)
        {
            PetImage? image = _petImageRepository.Read(imageId);
            if (image == null) return false;

            _petImageRepository.Delete(imageId);
            return true;
        }

        public IEnumerable<UserPetPublication> GetAll()
        {
            return _userPublicationRepository.GetAll();
        }
    }
}
