using Azure;
using Azure.Storage.Blobs.Models;

namespace Africuisine.Application;

public interface IAzureService
{
    Task<string> Upload(Stream stream, string fileName);
}
