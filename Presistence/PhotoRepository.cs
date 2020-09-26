using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Presistence
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationDbContext context;

        public PhotoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Photo>> GetPhotos(int productId)
        {
            return await context.Photos.Where(ph => ph.ProductId == productId).ToListAsync();
        }
        public  Photo RemovePhoto(Photo photo)
        {
             context.Photos.Remove(photo);
            return photo;
        }
        public async Task<Photo> GetPhotoAsync(int productId,int photoId)
        {
            return await context.Photos.SingleOrDefaultAsync(ph => ph.Id == photoId && ph.ProductId == productId);
        }
    }
}