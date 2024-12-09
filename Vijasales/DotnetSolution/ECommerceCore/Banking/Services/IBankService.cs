using Banking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
    public interface IBankService
    {
        Task<List<Account>> GetAllAsync();
        Task<Account> GetAccountAsync(string AccountNumber);
    }
}
