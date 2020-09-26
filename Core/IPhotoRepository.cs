using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.Core.Models;

namespace E_Commerce.Core
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetPhotos(int productId);
        Photo RemovePhoto(Photo photo);
        Task<Photo> GetPhotoAsync(int productId , int photoId);
    }
}