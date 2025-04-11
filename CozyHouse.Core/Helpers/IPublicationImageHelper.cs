using Microsoft.AspNetCore.Http;

namespace CozyHouse.Core.Helpers
{
    public interface IPublicationImageHelper
    {
        string SaveImage(IFormFile file);
        void DeleteImage(string? imagePath);
    }
}
