using System.Threading.Tasks;
using BlobStorage.Demo.Application.Interfaces;
using BlobStorage.Demo.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorage.Demo.Api.Controllers
{
    [Route("api/blobs")]
    [ApiController]
    public class BlobsController : ControllerBase
    {
        private readonly IBlobStorageService blobStorageService;

        public BlobsController(IBlobStorageService blobStorageService)
        {
            this.blobStorageService = blobStorageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blobs = await this.blobStorageService.ListBlobsAsync();

            return Ok(blobs);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var blobDownloadInfo = await this.blobStorageService.GetBlobAsync(name);

            return File(blobDownloadInfo.Content, blobDownloadInfo.ContentType, name);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromBody] UploadFileRequest request)
        {
            await blobStorageService.UploadFileBlobAsync(request.FilePath, request.FileName);

            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteByName(string name)
        {
            await blobStorageService.DeleteBlobAsync(name);

            return Ok();
        }
    }
}
