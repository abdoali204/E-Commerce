using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Controllers.Resources;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("/api/Payments")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentRepository PaymentRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PaymentsController(IPaymentRepository PaymentRepository , IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.PaymentRepository = PaymentRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetOrder()
        {
            return Ok(PaymentRepository.GetPayments());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            var Payment =await PaymentRepository.GetPaymentAsync(id);
            if(Payment == null)
                return NotFound();
            return Ok(mapper.Map<Payment,PaymentResource>(Payment));
        }
        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody]SavePaymentResource savePayment)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var Payment =  mapper.Map<SavePaymentResource,Payment>(savePayment);
            PaymentRepository.AddPayment(Payment);
            await unitOfWork.CompleteAsync();
            var PaymentResource = mapper.Map<Payment,PaymentResource>(Payment);
            return Ok(PaymentResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id,[FromBody]SavePaymentResource savePayment)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var Payment = await PaymentRepository.GetPaymentAsync(id);
            if(Payment == null)
                return NotFound();
            mapper.Map<SavePaymentResource,Payment>(savePayment,Payment);

            await unitOfWork.CompleteAsync();
            Payment = await PaymentRepository.GetPaymentAsync(Payment.Id);
            return Ok(mapper.Map<Payment,PaymentResource>(Payment));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePayment(int id)
        {
            var Payment = await PaymentRepository.GetPaymentAsync(id);
            if(Payment == null)
                return NotFound();
            PaymentRepository.RemovePayment(Payment);
            await unitOfWork.CompleteAsync();
            return Ok(mapper.Map<Payment,PaymentResource>(Payment));
        }
    }
}