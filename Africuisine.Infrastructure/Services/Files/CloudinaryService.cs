using Africuisine.Application.Data.Config;
using Africuisine.Domain.Repositories.Services;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
namespace Africuisine.Infrastructure.Services.Files
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly CloudinaryConfig Cloudinary;
        private readonly Account Account;
        public CloudinaryService(IOptions<CloudinaryConfig> options){
            Cloudinary = options.Value;
            Account = new Account(Cloudinary.Name, Cloudinary.Key, Cloudinary.Secret);
        }
        public async Task<string> Upload(Stream stream, string path)
        {
            var cloudinary = new Cloudinary(Account);
            FileDescription file = new() { FileName = path, Stream = stream };
            RawUploadParams upload = new() { File = file };
            var response = await cloudinary.UploadAsync(upload);
            return response.SecureUrl.ToString();
        }
    }
};