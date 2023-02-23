using CardApi.Models;
using CardApi.Models.Account;
using CardApi.Models.Cards;
using CardApi.Models.Matches;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CardApi.Controllers
{
    public class MatchController : ControllerBase
    {
        private readonly CardApiContext DB;


        private readonly ILogger<CardController> _logger;
        public MatchController(ILogger<CardController> logger, CardApiContext db)
        {
            DB = db;
            _logger = logger;
        }
        [HttpGet("{Id}")]
        public Match Get(Guid Id)
        {
            Match? match = DB.matches.Find(Id);
            if (match != null)
            {
                return match;
            }

            return null;
        }
        [HttpPost]
        public IActionResult MakeMatch(Guid player1)
        {
            User user1 = DB.Users.Find(player1);
            if (user1 == null)
            {
                return BadRequest();
            }

            DB.matches.Add(new Match(player1));
            DB.SaveChanges();
            return Ok();
        }
        [HttpPatch("MatchId")]
        public IActionResult AddPlayerTwo(Guid MatchId,Guid player2) {

            Match match = DB.matches.Find(MatchId);

            if(match == null) return NotFound();
            if(match.Player2 != null) return StatusCode(304);
           
            match.Player2 = player2;
            DB.matches.Update(match);

            return Ok();
        }
    }
}
