using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Entities;

namespace Banking.Repositories.Connected
{
    public interface ICardRepository
    {
        Task<List<Card>> GetAllAsync();
        Task<Card> GetCardAsync(string cardNumber);
    }
}
