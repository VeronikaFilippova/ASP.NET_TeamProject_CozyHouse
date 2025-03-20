using Microsoft.AspNetCore.Http;

namespace CozyHouse.Core.ServiceContracts
{
    public interface IImageService
    {
        string SaveImage(IFormFile file);
        void DeleteImage(string? imagePath);
    }
}
