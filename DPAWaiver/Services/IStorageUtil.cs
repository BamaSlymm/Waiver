using Google.Apis.Storage.v1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.IO;
using System.Threading.Tasks;

namespace DPAWaiver.Services
{
    public interface IStorageUtil
    {
        Task<Object> StoreFileAsync(IFormFile incoming, string bucketId);
        Task GetFileAsync(string objectName, Stream copyToStream);
        Task DeleteFileAsync(string URI);

    }
}