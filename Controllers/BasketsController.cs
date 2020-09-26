using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Controllers.Resources;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("/api/baskets")]
    public class BasketsController : Controller
    {
        private readonly IBasketRepository basketRepositry;
        private readonly IUnitOfWork unitOfWok;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public BasketsController(IBasketRepository basketRepositry,IUnitOfWork unitOfWok,IMapper mapper,
                                 IProductRepository productRepository )
        {
            this.basketRepositry = basketRepositry;
            this.unitOfWok = unitOfWok;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasket(int id)
        {
            var basket =await basketRepositry.GetBasketAsync(id);
            if(basket == null)
                return NotFound();
            return Ok(mapper.Map<Basket,BasketResource>(basket));  
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody]SaveBasketResource basketResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var basket = mapper.Map<SaveBasketResource,Basket>(basketResource);
            if (basket.BasketItems.Any( item => item.ProductId ==0))
                basket = new Basket(){BasketItems = new OrderDetails[]{}};
            basketRepositry.AddBasket(basket);
            await unitOfWok.CompleteAsync();
            basket = await basketRepositry.GetBasketAsync(basket.BasketId);
            var result = mapper.Map<Basket,BasketResource>(basket);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBasket(int id,[FromBody]SaveBasketResource basketResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var basket = await basketRepositry.GetBasketAsync(id);
            if(basket == null)
                return NotFound();

            mapper.Map<SaveBasketResource,Basket>(basketResource,basket);
            
            await unitOfWok.CompleteAsync();
            basket = await basketRepositry.GetBasketAsync(basket.BasketId);
            var result = mapper.Map<Basket,BasketResource>(basket);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketAsync(int id)
        {
            var basket = await basketRepositry.GetBasketAsync(id);
            if(basket == null)
                return NotFound();
            
            basketRepositry.DeleteBasket(basket);
            await unitOfWok.CompleteAsync();
            return Ok(basket);
        }
    }
}