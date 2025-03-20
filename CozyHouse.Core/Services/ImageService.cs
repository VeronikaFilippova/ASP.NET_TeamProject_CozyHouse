using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CozyHouse.Core.Services
{
    public class ImageService : IImageService
    {
        IWebHostEnvironment _webHostEnvironment;
        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void DeleteImage(string? imagePath)
        {
            if (imagePath == null) return;

            string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('\\'));
            if (File.Exists(oldImagePath))
            {
                File.Delete(oldImagePath);
            }
        }

        public string SaveImage(IFormFile file)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string productPath = Path.Combine(_webHostEnvironment.WebRootPath, @"PetImages");

            using (FileStream fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return @"\PetImages\" + fileName;
        }
    }
}
