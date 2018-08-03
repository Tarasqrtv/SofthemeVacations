using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Vacations.BLL.Services
{
    public class ImagesService : IImagesService
    {
        private CloudBlobContainer _blobContainer;
        private readonly CloudBlobClient _blobClient;

        public ImagesService(
            IConfiguration configuration
            )
        {
            var storageConnectionString = configuration.GetConnectionString("StorageConnectionString");

            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            _blobClient = storageAccount.CreateCloudBlobClient();

        }

        public async Task<string> GetUrlAsync(string imgName)
        {
            _blobContainer = _blobClient.GetContainerReference("images");
            await _blobContainer.CreateIfNotExistsAsync();

            await _blobContainer.SetPermissionsAsync(
                new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob }
                );

            var blockBlob = _blobContainer.GetBlockBlobReference(imgName);

            if (await blockBlob.ExistsAsync())
            {
                return blockBlob.Uri.AbsoluteUri;
            }

            blockBlob = _blobContainer.GetBlockBlobReference("default");
            return blockBlob.Uri.AbsoluteUri;
        }
    }
}
