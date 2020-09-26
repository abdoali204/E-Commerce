using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Controllers.Resources;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace E_Commerce.Controllers
{
    [Route("/api/products/{productId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IWebHostEnvironment hostEnv;
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IPhotoService photoService;
        private readonly IOptionsSnapshot<PhotoSettings> options;
        private readonly IPhotoRepository photoRepository;
        private readonly PhotoSettings photoSettings;

        public PhotosController(IWebHostEnvironment hostEnv,IProductRepository productRepository,
                                IUnitOfWork unitOfWork,IMapper mapper,IPhotoService photoService,
                                IOptionsSnapshot<PhotoSettings> options,IPhotoRepository photoRepository)
        {
            this.hostEnv = hostEnv;
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.photoService = photoService;
            this.options = options;
            this.photoRepository = photoRepository;
            this.photoSettings = options.Value;
        }
        [HttpPost]
        public async Task<IActionResult> UploadAsync(int productId ,[FromForm(Name="file")] IFormFile file)
        {
            var product =await this.productRepository.GetProduct(productId);
            if(product == null)
                return NotFound();
            if(file.Length == 0)
                return BadRequest("Empty Photo");
            if(file.Length > photoSettings.MaxBytes)
                return BadRequest("Exceeding File Limit");
            if(!photoSettings.IsSupported(file.FileName))
                return BadRequest("Not Supported File Type");
            var uploadFolderPath = Path.Combine(hostEnv.WebRootPath,"uploads");
            uploadFolderPath = Path.Combine(uploadFolderPath, "products");
            var photo = await photoService.UploadPhoto(product,file,uploadFolderPath);
            return Ok(mapper.Map<Photo, PhotoResource>(photo));
        }
        [HttpGet]
        public async Task<IEnumerable<PhotoResource>> GetPhotos(int productId)
        {
            var photos = await this.photoRepository.GetPhotos(productId);
            return mapper.Map<IEnumerable<Photo>,IEnumerable<PhotoResource>>(photos);
        }
        [HttpDelete("{photoId}")]
        public async Task<IActionResult> RemovePhoto(int productId,int photoId)
        {
            var photo =await photoRepository.GetPhotoAsync(productId,photoId);
            if(photo == null)
                return NotFound();
            photo =  photoRepository.RemovePhoto(photo);
            await unitOfWork.CompleteAsync();
            return Ok(photo);
        }
    }
}