using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Controllers.Resources;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("/api/products")]
    public class ProductsController: Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepository,IUnitOfWork unitOfWork,
                                  IMapper mapper)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(ProductQueryResource queryResource)
        {
            var filter = mapper.Map<ProductQueryResource,ProductQuery>(queryResource);
            var products = await productRepository.GetProducts(filter);
            var productResources = mapper.Map<QueryResult<Product> , QueryResultResource<ProductResource> >(products);
            return Ok(productResources);
        }
        [HttpGet("{id}")]
   
        public async Task<IActionResult> GetProduct(int id)
        {
            var prod = await productRepository.GetProduct(id);
            if(prod == null)
                return NotFound();
            var productResource = mapper.Map<Product,ProductResource>(prod);
            return Ok(prod);
        }
        [HttpPost]

        public async Task<IActionResult> AddProductAsync([FromBody]SaveProductResource saveProductResource)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            var product = Mapper.Map<SaveProductResource,Product>(saveProductResource);

            productRepository.Add(product);
            await unitOfWork.CompleteAsync();

            product =await productRepository.GetProduct(product.Id);
            var productResource = mapper.Map<Product,ProductResource>(product);
            return Ok(productResource);
        }
        [HttpGet]
        [Route("/api/products/categories")]
        public IActionResult GetCategories()
        {
            return Ok(productRepository.GetCategories());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,[FromBody]SaveProductResource producToUpdate)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            Product product = await productRepository.GetProduct(id);
            if(product == null)            
                return NotFound();
            mapper.Map<SaveProductResource,Product>(producToUpdate,product);
            await unitOfWork.CompleteAsync();
            product = await productRepository.GetProduct(product.Id);
            return Ok(mapper.Map<Product,ProductResource>(product));
        } 
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var product = await productRepository.GetProduct(id);
            if(product == null)
                return NotFound();
            productRepository.Remove(product);
            await unitOfWork.CompleteAsync();
            return Ok(mapper.Map<Product,ProductResource>(product));
        }
    }
}