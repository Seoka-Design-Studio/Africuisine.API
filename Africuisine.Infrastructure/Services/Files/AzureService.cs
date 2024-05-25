using Africuisine.Application;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;

namespace Africuisine.Infrastructure;

public class AzureService : IAzureService
{
    private readonly AzureConfig _azure;
    private readonly BlobContainerClient _containerClient;
    private readonly BlobServiceClient _azureClient;


    public AzureService(BlobServiceClient blobClient, IOptions<AzureConfig> options)
    {
        _azureClient = blobClient;
        _azure = options.Value;
        _containerClient = blobClient.GetBlobContainerClient(_azure.ContainerName);

    }

    public async Task<string> Upload(Stream stream, string fileName)
    {
       await _containerClient.CreateIfNotExistsAsync();
       var client = _containerClient.GetBlobClient(fileName);
       await client.UploadAsync(stream, overwrite: true);
       return client.Uri.ToString();
    }
}
