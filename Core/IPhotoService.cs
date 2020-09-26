using System.Threading.Tasks;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Core
{
    public interface IPhotoService
    {
        Task<Photo> UploadPhoto(Product product,IFormFile file,string uploadFolderPath);
    }
}