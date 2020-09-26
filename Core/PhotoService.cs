using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Core
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PhotoService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Photo> UploadPhoto(Product product, IFormFile file, string uploadFolderPath)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadFolderPath,fileName);
            using(var stream = new FileStream(filePath,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var photo = new Photo(){FileName = fileName};
            product.Photos.Add(photo);
            await unitOfWork.CompleteAsync();
            return photo;
        }

    }
}