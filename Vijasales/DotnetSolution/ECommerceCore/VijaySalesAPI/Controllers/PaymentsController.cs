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

        [HttpGet("user/{customerId}")]
        public async Task<ActionResult<List<Payment>>> GetPaymentsByUser(int customerId)
        {
            var payments = await _paymentService.GetPaymentsByCustomerIdAsync(customerId);
            if (payments == null || payments.Count == 0)
            {
                return NotFound($"No payments found for user with ID {customerId}");
            }
            return Ok(payments);
        }

        // POST api/payment/paynow
        [HttpPost("paynow")]
        public async Task<IActionResult> PayNow([FromBody] PaymentData paymentData)
        {
            // Extract data from the dynamic object

            if (paymentData == null)
            { return BadRequest("Invalid payment data."); }

            int orderId = Convert.ToInt32(paymentData.OrderId.ToString());
            // Ensure it's properly handled
            string accountNumber = paymentData.AccountNumber.ToString();
            string paymentMethod = paymentData.PaymentMethod.ToString();
            if(paymentMethod == "creditDebitCard")
            {

            }
            if (orderId<=0 || string.IsNullOrEmpty(accountNumber) || string.IsNullOrEmpty(paymentMethod))
            {
                return BadRequest(new { success = false, message = "Invalid payment data" });
            }
            // Validate the incoming request data (for example, check for required fields)
      

            // Call your payment processing logic here (e.g., verifying the card or processing the payment)
            bool paymentSuccessful = await _paymentService.PayNow(orderId,accountNumber,paymentMethod);

            if (paymentSuccessful)
            {
                return Ok(new { success = true, message = "Payment successful" });
            }
            else
            {
                return Ok(new { success = false, message = "Payment failed" });
            }
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
