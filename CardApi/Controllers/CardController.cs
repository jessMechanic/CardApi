using CardApi.Models;
using CardApi.Models.Account;
using CardApi.Models.Cards;
using Microsoft.AspNetCore.Mvc;

namespace CardApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly CardApiContext DB;
       

        private readonly ILogger<CardController> _logger;

        public CardController(ILogger<CardController> logger , CardApiContext db)
        {
            DB = db;
            _logger = logger;


            DB.Add(new Card() { Name = "card1", Type = CardType.Defence });
            DB.SaveChanges();
        }

        [HttpGet("/api/cards/getall")]
        public IEnumerable<Card> Get()
        {
            return DB.Cards.ToArray();
        }


        [HttpPost("/api/route/location")]
        public IActionResult AddCard(Card card)
        {

            DB.Add(new Card() { Name = card.Name, Type = card.Type });
            DB.SaveChanges();
            return Ok();
        }


        [HttpGet("/api/User")]
        public IEnumerable<User> GetDeck()
        {      
            return DB.Users.ToArray();
        }



    }
}