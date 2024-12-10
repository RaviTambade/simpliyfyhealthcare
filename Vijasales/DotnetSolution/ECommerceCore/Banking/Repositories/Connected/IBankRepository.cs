using Banking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Repositories.Connected
{
    public interface IBankRepository
    {
        Task<List<Account>> GetAllAsync();
        Task<Account> GetAccountAsync(string accountNumber);
    }
}
