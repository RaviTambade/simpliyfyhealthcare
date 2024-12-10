using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Entities;
using Banking.Repositories.Connected;

namespace Banking.Services
{
    public class CardServices : ICardService
    {
        private ICardRepository _repo;
        public CardServices(ICardRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Card>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }



        public async Task<Card> GetCardAsync(string cardNumber)
        {
            return await _repo.GetCardAsync(cardNumber);
        }
    }
}
