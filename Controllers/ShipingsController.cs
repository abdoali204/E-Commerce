using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Controllers.Resources;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace E_Commerce.Controllers
{
    [Route("/api/shippings")]
    public class ShippingsController : Controller
    {
        private readonly IShippingRepository shippingRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IOptionsSnapshot<ShippingSettings> optionSnapshot;
        private readonly ShippingSettings shippingSettings;
        public ShippingsController(IShippingRepository shippingRepository , IUnitOfWork unitOfWork,IMapper mapper,IOptionsSnapshot<ShippingSettings> optionSnapshot)
        {
            this.shippingRepository = shippingRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.optionSnapshot = optionSnapshot;
            this.shippingSettings = optionSnapshot.Value;
        }
        [HttpGet]
        public IActionResult GetOrder()
        {
            return Ok(shippingRepository.GetShippings());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipping(int id)
        {
            var shipping =await shippingRepository.GetShippingAsync(id);
            if(shipping == null)
                return NotFound();
            return Ok(mapper.Map<Shipping,ShippingResource>(shipping));
        }
        [HttpPost]
        public async Task<IActionResult> AddShipping([FromBody]SaveShippingResource saveShipping)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                saveShipping.ShippingCharge = shippingSettings.ShippingCharge;
                
            var shipping =  mapper.Map<SaveShippingResource,Shipping>(saveShipping);
            shipping.ShippingCharge = shippingSettings.ShippingCharge;
            shipping.ShippingMethod = shippingSettings.ShippingMethod;
            shippingRepository.AddShipping(shipping);
            await unitOfWork.CompleteAsync();
            var shippingResource = mapper.Map<Shipping,ShippingResource>(shipping);
            return Ok(shippingResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipping(int id,[FromBody]SaveShippingResource saveShipping)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var shipping = await shippingRepository.GetShippingAsync(id);
            if(shipping == null)
                return NotFound();
            mapper.Map<SaveShippingResource,Shipping>(saveShipping,shipping);

            await unitOfWork.CompleteAsync();
            shipping = await shippingRepository.GetShippingAsync(shipping.Id);
            return Ok(mapper.Map<Shipping,ShippingResource>(shipping));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveShipping(int id)
        {
            var shipping = await shippingRepository.GetShippingAsync(id);
            if(shipping == null)
                return NotFound();
            shippingRepository.RemoveShipping(shipping);
            await unitOfWork.CompleteAsync();
            return Ok(mapper.Map<Shipping,ShippingResource>(shipping));
        }
    }
}