using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1.Data;
using System.IO;
using Google;
using System;

namespace DPAWaiver.Services
{
    public class StorageUtil : IStorageUtil
    {

        private StorageClient _storageClient;
        public StorageUtil(IOptions<GoogleCloudStorageOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
            var credential = GoogleCredential.FromFile(Options.APICredentialLocation);
            _storageClient = StorageClient.Create(credential);
        }

        public GoogleCloudStorageOptions Options { get; } //set only via Secret Manager

        public async Task<Google.Apis.Storage.v1.Data.Object> StoreFileAsync(IFormFile incoming, string bucketId)
        {
            Google.Apis.Storage.v1.Data.Object storedObject = null ;
            try
            {
                storedObject = await _storageClient.UploadObjectAsync(
                   bucket: Options.BucketName,
                   objectName: bucketId + "/" + incoming.FileName,
                   contentType: incoming.ContentType,
                   source: incoming.OpenReadStream()
               );
            }
            catch (GoogleApiException gae)
            {
                Console.WriteLine(gae.Error.Code);
            }
            return storedObject;
        }

        public async Task GetFileAsync(string objectName, Stream copyToStream)
        {
            await _storageClient.DownloadObjectAsync(Options.BucketName,
                                                     objectName,
                                                     copyToStream);
        }


        public async Task DeleteFileAsync(string objectName)
        {
            try
            {
                await _storageClient.DeleteObjectAsync(Options.BucketName,
                                                        objectName);
            }
            catch (GoogleApiException gae)
            {
                if (gae.Error.Code != 404)
                {
                    throw gae;
                }
            }
        }
    }
}