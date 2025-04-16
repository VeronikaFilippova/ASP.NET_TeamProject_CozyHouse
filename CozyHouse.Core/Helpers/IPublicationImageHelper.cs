using Microsoft.AspNetCore.Http;

namespace CozyHouse.Core.Helpers
{
    /// <summary>
    /// Defines helper methods for saving and deleting image files within the <c>wwwroot</c> folder.
    /// </summary>
    public interface IPublicationImageHelper
    {
        /// <summary>
        /// Saves the specified image file to the <c>wwwroot</c> folder and returns the relative path.
        /// </summary>
        /// <param name="file">The image file to save.</param>
        /// <returns>The relative path to the saved image file.</returns>
        string SaveImage(IFormFile file);
        /// <summary>
        /// Deletes the image file at the specified relative path from the <c>wwwroot</c> folder.
        /// </summary>
        /// <param name="imagePath">The relative path to the image file to delete. If null, the method does nothing.</param>
        void DeleteImage(string? imagePath);
    }
}
