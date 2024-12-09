using Banking.Entities;
using Banking.Repositories.Connected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
    public class BankService:IBankService
    {
        private IBankRepository _repo;
        public BankService(IBankRepository repo)
        {
            _repo = repo;
        }

        public async Task<Account> GetAccountAsync(string AccountNumber)
        {
            return await _repo.GetAccountAsync(AccountNumber);
        }


        public async Task<List<Account>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}
