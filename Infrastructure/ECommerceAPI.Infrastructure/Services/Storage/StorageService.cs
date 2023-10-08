using ECommerceAPI.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name;  }

        public Task DeleteAsync(string pathOrContainerName, string fileName)
        => _storage.DeleteAsync(pathOrContainerName, fileName);

        public List<string> GetFiles(string pathrContainerName)
        => _storage.GetFiles(pathrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName)
        => _storage.HasFile(pathOrContainerName, fileName);

        public Task<List<(string fileName, string pathOrContainerName)>> uploadAsync(string pathOrContainerName, IFormFileCollection files)
        => _storage.uploadAsync(pathOrContainerName, files);
    }
}
