using Microsoft.AspNetCore.StaticFiles;

namespace BlobStorage.Demo.Application.Extensions
{
    public static class FileExtensions
    {
        private static readonly FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider();

        public static string GetContentType(this string fileName)
        {
            if(!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
