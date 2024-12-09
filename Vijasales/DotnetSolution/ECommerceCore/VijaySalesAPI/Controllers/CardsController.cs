using Microsoft.AspNetCore.Mvc;
using Banking.Entities;
using Banking.Repositories.Connected;
using Banking.Services;


namespace VijaySalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpGet]
        public async Task<List<Card>> Get()
        {
            List<Card> cards = await _cardService.GetAllAsync();
            return cards;
        }
        // GET api/<CardsController>/5
        [HttpGet("{cardNumber}")]
        public async Task<Card> Get(string cardNumber)
        {
            Card card = await _cardService.GetCardAsync(cardNumber);
            return card;
        }
    }
}
