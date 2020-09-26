using System;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Controllers.Resources;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("/api/orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrdersController(IOrderRepository orderRepository , IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetOrder()
        {
            return Ok(orderRepository.GetOrders());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            var order =await orderRepository.GetOrderAsync(id);
            if(order == null)
                return NotFound();
            return Ok(mapper.Map<Order,OrderResource>(order));
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody]SaveOrderResource saveOrder)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var order =  mapper.Map<SaveOrderResource,Order>(saveOrder);
            order.Date = DateTime.Now;
            order.State = "Placed";
            orderRepository.AddOrder(order);
            await unitOfWork.CompleteAsync();
            var orderResource = mapper.Map<Order,OrderResource>(order);
            return Ok(orderResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id,[FromBody]SaveOrderResource saveOrder)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var order = await orderRepository.GetOrderAsync(id);
            if(order == null)
                return NotFound();
            mapper.Map<SaveOrderResource,Order>(saveOrder,order);

            await unitOfWork.CompleteAsync();
            order = await orderRepository.GetOrderAsync(order.Id);
            return Ok(mapper.Map<Order,OrderResource>(order));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            var order = await orderRepository.GetOrderAsync(id);
            if(order == null)
                return NotFound();
            orderRepository.RemoveOrder(order);
            await unitOfWork.CompleteAsync();
            return Ok(mapper.Map<Order,OrderResource>(order));
        }
    }
}