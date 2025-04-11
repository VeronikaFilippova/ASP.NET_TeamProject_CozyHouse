using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Helpers;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Core.Services
{
    public class ShelterPetPublicationService : IShelterPetPublicationService
    {
        private readonly IShelterPetPublicationRepository _shelterPublicationRepository;
        private readonly IPetImageRepository _petImageRepository;
        private readonly IPublicationImageHelper _imageSaveHelper;
        public ShelterPetPublicationService(IShelterPetPublicationRepository publicationRepository, IPetImageRepository imageRepository, IPublicationImageHelper helper)
        {
            _shelterPublicationRepository = publicationRepository;
            _petImageRepository = imageRepository;
            _imageSaveHelper = helper;
        }
        public ShelterPetPublication? Get(Guid publicationId)
        {
            return _shelterPublicationRepository.Read(publicationId);
        }
        public bool Add(ShelterPetPublication publication, IFormFile[] files)
        {
            bool isValid = Validator.TryValidateObject(publication, new ValidationContext(publication), null);
            if (isValid == false) return false;

            _shelterPublicationRepository.Create(publication);
            foreach (IFormFile file in files)
            {
                string filePath = _imageSaveHelper.SaveImage(file);
                PetImage image = new PetImage() { ImageUrl = filePath, PetPublicationId = publication.Id };
                _petImageRepository.Create(image);
            }
            return true;
        }

        public bool Update(ShelterPetPublication publication)
        {
            bool isValid = Validator.TryValidateObject(publication, new ValidationContext(publication), null);
            if (isValid == false) return false;
            _shelterPublicationRepository.Update(publication);
            return true;
        }

        public bool Delete(Guid id)
        {
            ShelterPetPublication? publication = _shelterPublicationRepository.Read(id);
            if (publication == null) return false;

            foreach (PetImage image in publication.Images)
            {
                _imageSaveHelper.DeleteImage(image.ImageUrl);
            }
            _shelterPublicationRepository.Delete(id);
            return true;
        }

        public IEnumerable<ShelterPetPublication> GetAll()
        {
            return _shelterPublicationRepository.GetAll();
        }

        public bool AddImage(Guid publicationId, IFormFile file)
        {
            ShelterPetPublication? publication = _shelterPublicationRepository.Read(publicationId);
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
    }
}
