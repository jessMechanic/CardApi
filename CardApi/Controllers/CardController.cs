using CardApi.Models;
using CardApi.Models.Account;
using CardApi.Models.Cards;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardApi.Controllers
{
    [ApiController]
    [Route("cards")]
    public class CardController : ControllerBase
    {
        private readonly CardApiContext DB;


        private readonly ILogger<CardController> _logger;

        public CardController(ILogger<CardController> logger, CardApiContext db)
        {
            DB = db;
            _logger = logger;



            DB.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Card> Get()
        {
            return DB.Cards.ToArray();
        }

        [HttpGet("{Id}")]
        public Card Get(Guid Id)
        {
            Card? card = DB.Cards.Find(Id);
            if (card != null)
            {
                return card;
            }

            return null;
        }

        [HttpGet("find/{name}")]
        public IEnumerable<Card> Search(string name)
        {
            return DB.Cards.Where(a => a.Name.ToLower().Contains(name.ToLower())); ;

        }


        [HttpPost]
        public IActionResult AddCard(Card card)
        {

            DB.Add(new Card() { Name = card.Name, Type = card.Type });
            DB.SaveChanges();
            return Ok();
        }

        [HttpDelete("{Id}")]

        public IActionResult DeleteCard(Guid Id)
        {
            Card? card = DB.Cards.Find(Id);
            if (card == null)
            {
                return NotFound();
            }

            try
            {
                DB.Cards.Remove(card);
                DB.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500); 

            }
         

        }


    }
}