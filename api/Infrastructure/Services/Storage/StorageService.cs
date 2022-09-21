using Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services.Storage;

public class StorageService : IStorageService
{
     readonly IStorage _storage;

     public StorageService(IStorage storage)
     {
          _storage = storage;
     }

     public string StorageName { get => _storage.GetType().Name; }

     public List<string> GetFiles(string pathOrContainerName)
          => _storage.GetFiles(pathOrContainerName);

     public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
          => _storage.UploadAsync(pathOrContainerName, files);

     public bool HasFile(string pathOrContainerName, string fileName)
          => _storage.HasFile(pathOrContainerName, fileName);

     public async Task DeleteAsync(string pathOrContainerName, string fileName)
          => await _storage.DeleteAsync(pathOrContainerName, fileName);
}
