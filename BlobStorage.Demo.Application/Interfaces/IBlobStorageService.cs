using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace BlobStorage.Demo.Application.Interfaces
{
    public interface IBlobStorageService
    {
        public Task<BlobDownloadInfo> GetBlobAsync(string name);

        public Task<IEnumerable<string>> ListBlobsAsync();

        public Task UploadFileBlobAsync(string filePath, string fileName);

        public Task UploadContentBlobAsync(string content, string fileName);

        public Task DeleteBlobAsync(string blobName);
    }
}
