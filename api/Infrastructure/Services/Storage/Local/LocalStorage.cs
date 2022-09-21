using Application.Abstractions.Storage;
using Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services.Storage;

public class LocalStorage : Storage, ILocalStorage
{
     private readonly IWebHostEnvironment _webHostEnvironment;

     public LocalStorage(IWebHostEnvironment webHostEnvironment)
     {
          _webHostEnvironment = webHostEnvironment;
     }

     public List<string> GetFiles(string path)
     {
          DirectoryInfo directory = new(path);
          return directory.GetFiles().Select(f => f.Name).ToList();
     }

     public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
     {
          string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
          if (!Directory.Exists(uploadPath))
               Directory.CreateDirectory(uploadPath);

          List<(string fileName, string path)> datas = new();
          List<bool> results = new();
          foreach (IFormFile file in files)
          {
               string fileNewName = await FileRenameAsync(path, file.Name, HasFile);

               bool result = await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
               datas.Add((fileNewName, $"{path}\\{fileNewName}"));
               results.Add(result);
          }

          if (results.TrueForAll(r => r.Equals(true)))
               return datas;

          return null;
     }

     public bool HasFile(string path, string fileName)
          => File.Exists($"{path}\\{fileName}");

     public async Task DeleteAsync(string path, string fileName)
          => File.Delete($"{path}\\{fileName}");

     public async Task<bool> CopyFileAsync(string path, IFormFile file)
     {
          try
          {
               await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

               await file.CopyToAsync(fileStream);
               await fileStream.FlushAsync();
               return true;
          }
          catch (Exception ex)
          {
               //todo log!
               throw ex;
          }
     }
}
