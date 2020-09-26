using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Controllers.Resources;
using E_Commerce.Core;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("/api/Invoices")]
    public class InvoicesController : Controller
    {
        private readonly IInvoiceRepository InvoiceRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public InvoicesController(IInvoiceRepository InvoiceRepository , IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.InvoiceRepository = InvoiceRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetOrder()
        {
            return Ok(InvoiceRepository.GetInvoices());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var Invoice =await InvoiceRepository.GetInvoiceAsync(id);
            if(Invoice == null)
                return NotFound();
            return Ok(mapper.Map<Invoice,InvoiceResource>(Invoice));
        }
        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromBody]InvoiceResource saveInvoice)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var Invoice =  mapper.Map<InvoiceResource,Invoice>(saveInvoice);
            InvoiceRepository.AddInvoice(Invoice);
            await unitOfWork.CompleteAsync();
            var InvoiceResource = mapper.Map<Invoice,InvoiceResource>(Invoice);
            return Ok(InvoiceResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id,[FromBody]InvoiceResource saveInvoice)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var Invoice = await InvoiceRepository.GetInvoiceAsync(id);
            if(Invoice == null)
                return NotFound();
            mapper.Map<InvoiceResource,Invoice>(saveInvoice,Invoice);

            await unitOfWork.CompleteAsync();
            Invoice = await InvoiceRepository.GetInvoiceAsync(Invoice.Id);
            return Ok(mapper.Map<Invoice,InvoiceResource>(Invoice));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveInvoice(int id)
        {
            var Invoice = await InvoiceRepository.GetInvoiceAsync(id);
            if(Invoice == null)
                return NotFound();
            InvoiceRepository.RemoveInvoice(Invoice);
            await unitOfWork.CompleteAsync();
            return Ok(mapper.Map<Invoice,InvoiceResource>(Invoice));
        }
    }
}