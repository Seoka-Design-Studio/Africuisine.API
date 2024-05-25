namespace Africuisine.Domain.Repositories.Services
{
    public interface ICloudinaryService
    {
        Task<string> Upload(Stream stream, string name);
    }
}