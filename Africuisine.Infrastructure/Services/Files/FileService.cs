using Africuisine.Application;
using Africuisine.Domain.Repositories.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Africuisine.Infrastructure.Services.Files
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IAzureService _azureService;

        public FileService(IWebHostEnvironment environment, IAzureService azureService, ICloudinaryService cloudinaryService)
        {
            _environment = environment;
            _azureService = azureService;
            _cloudinaryService = cloudinaryService;
        }

        public string GenerateUploadPath(string mediaType, string folder, string name)
        {
            return Path.Combine(mediaType, folder, name);
        }

        public string GenerateUri(string path, HttpRequest request)
        {
            var baseUri = $"{request.Scheme}://{request.Host}/api/";
            var relativePath = path.Replace(AppDomain.CurrentDomain.BaseDirectory, "").Replace("\\", "/");
            return $"{baseUri}{relativePath}";
        }

        public string GetFileExtension(string name)
        {
            string extension = Path.GetExtension(name);
            return extension;
        }

        public async Task<string> Upload(Stream stream, string path)
        {
            string uri;
            if (_environment.IsDevelopment())
            {
                uri = await _cloudinaryService.Upload(stream, path);
                return uri;
            }
            uri = await _azureService.Upload(stream, path);
            return uri;
        }
    }
}