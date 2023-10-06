using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.Services
{
    public interface IFileService
    {
        Task<List<(string fileName, string path)>> UpdateAsync(string path, IFormFileCollection files);


        Task<bool>CopyFileAsync(string path, IFormFile file);
    }
}
