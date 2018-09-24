using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;

namespace DPAWaiver.Services
{
    public class StorageUtil : IStorageUtil
    {
        
        private StorageClient _storageClient ;
        public StorageUtil(IOptions<GoogleCloudStorageOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
            var credential = GoogleCredential.FromFile(Options.APICredentialLocation);
            _storageClient = StorageClient.Create(credential);
        }

        public GoogleCloudStorageOptions Options { get; } //set only via Secret Manager

        public async Task<string> StoreFileAsync(IFormFile incoming, string bucketId)
        {
            var parentBucket = await _storageClient.GetBucketAsync(Options.BucketName);
            var storedObject = await _storageClient.UploadObjectAsync(
                bucket:Options.BucketName,
                objectName: bucketId + "/" + incoming.FileName,
                contentType: incoming.ContentType,
                source: incoming.OpenReadStream()
            );
            return storedObject.Name;
        }

        public async Task GetFileAsync(string URI)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteFileAsync(string URI)
        {
            throw new System.NotImplementedException();
        }
    }
}