using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BlobStorage.Demo.Application.Extensions;
using BlobStorage.Demo.Application.Interfaces;

namespace BlobStorage.Demo.Application.Implementations
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient blobServiceClient;

        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public Task DeleteBlobAsync(string blobName)
        {
            var containerClient = this.blobServiceClient.GetBlobContainerClient("youtube");
            var blobClient = containerClient.GetBlobClient(blobName);
            return blobClient.DeleteIfExistsAsync();
        }

        public async Task<BlobDownloadInfo> GetBlobAsync(string blobName)
        {
            var containerClient = this.blobServiceClient.GetBlobContainerClient("youtube");
            var blobClient = containerClient.GetBlobClient(blobName);

            var blobDownloadInfo = await blobClient.DownloadAsync();

            return blobDownloadInfo.Value;
        }

        public async Task<IEnumerable<string>> ListBlobsAsync()
        {
            var containerClient = this.blobServiceClient.GetBlobContainerClient("youtube");
            var items = new List<string>();

            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                items.Add(blobItem.Name);
            }

            return items;
        }

        public Task UploadContentBlobAsync(string content, string fileName)
        {
            throw new System.NotImplementedException();
        }

        public async Task UploadFileBlobAsync(string filePath, string fileName)
        {
            var containerClient = this.blobServiceClient.GetBlobContainerClient("youtube");
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(filePath, new BlobHttpHeaders { ContentType = filePath.GetContentType() });
        }
    }
}
