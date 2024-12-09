using Catalog.Entities;
using Catalog.Services;
using Microsoft.AspNetCore.Mvc;
using PaymentProcessing.Entities;
using PaymentProcessing.Repositories;
using PaymentProcessing.Services;

namespace VijaySalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentServices _paymentService;
        public PaymentsController(IPaymentServices paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        public async  Task<List<Payment>> Get()
        {
            List<Payment> payments = await _paymentService.GetAllAsync();
            return payments;
        }
        // GET api/<PaymentsController>/5
        [HttpGet("{id}")]
        public async Task<Payment> Get(int id)
        {
            Payment payment = await _paymentService.GetPaymentAsync(id);
            return payment;
        }
        [HttpPost]
        public async void Post([FromBody] Payment payment)
        {
            //await _paymentService.InsertPaymentAsync(payment);
            //procedure
            //await _paymentService.UpdatePaymentAsync(payment);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
