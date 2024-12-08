using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using Catalog.Services;
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
        [HttpGet("{id}")]
        public async Task<Card> Get(int id)
        {
            Card card = await _cardService.GetCardAsync(id);
            return card;
        }
    }
}
