using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CozyHouse.Core.Helpers
{
    public class PublicationImageHelper : IPublicationImageHelper
    {
        IWebHostEnvironment _webHostEnvironment;
        public PublicationImageHelper(IWebHostEnvironment webHostEnvironment)
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
