using Azure.Storage.Blobs;
using BlobStorage.Demo.Application.Implementations;
using BlobStorage.Demo.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlobStorage.Demo.Application
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, 
            IConfiguration configuration)
        {

            var blobStorageConnectionString = configuration.GetSection("AzureBlobStorageConnectioString").Value;

            services.AddSingleton(options => new BlobServiceClient(blobStorageConnectionString));
            services.AddScoped<IBlobStorageService, BlobStorageService>();

            return services;
        }
    }
}
