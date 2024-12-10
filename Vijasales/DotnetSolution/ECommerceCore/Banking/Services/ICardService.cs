using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Entities;

namespace Banking.Services
{
    public interface ICardService
    {
        Task<List<Card>> GetAllAsync();
        Task<Card> GetCardAsync(string cardNumber);
    }
}
