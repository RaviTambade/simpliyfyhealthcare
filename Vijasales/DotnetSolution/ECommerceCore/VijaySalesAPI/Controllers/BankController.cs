using Banking.Entities;
using Banking.Services;
using Microsoft.AspNetCore.Mvc;

namespace VijaySalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }
        [HttpGet]
        public async Task<List<Account>> Get()
        {
            List<Account> accounts = await _bankService.GetAllAsync();
            return accounts;
        }
        // GET api/<accountsController>/5
        [HttpGet("{accountNumber}")]
        public async Task<Account> Get(string accountNumber)
        {
            Account account = await _bankService.GetAccountAsync(accountNumber);
            return account;
        }
    }
}
