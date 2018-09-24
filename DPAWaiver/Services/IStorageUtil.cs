using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace DPAWaiver.Services
{
    public interface IStorageUtil
    {
        Task<string> StoreFileAsync(IFormFile incoming, string bucketId);
        Task GetFileAsync(string URI);

        Task DeleteFileAsync(string URI);

    }
}