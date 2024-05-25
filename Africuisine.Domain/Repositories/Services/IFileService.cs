using Microsoft.AspNetCore.Http;

namespace Africuisine.Domain.Repositories.Services
{
    public interface IFileService
    {
        Task<string> Upload(Stream stream, string path);
        string GetFileExtension(string name);
        string GenerateUploadPath(string mediaType, string folder, string name);
        string GenerateUri(string path, HttpRequest request);
    }
}