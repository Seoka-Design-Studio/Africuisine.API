namespace Africuisine.Domain.Repositories.Repository.Ingredients
{
    internal interface IFileService
    {
        Task<string> UploadFileToAzure(Stream file);
    }
}
