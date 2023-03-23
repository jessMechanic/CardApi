using CardApi.Models;
using CardApi.Models.Account;
using CardApi.Models.Matches;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace CardApi.Controllers
{
    [ApiController]
    [Route("Match")]
    public class MatchController : ControllerBase
    {
        private readonly CardApiContext DB;
        static Random rand = new Random();

        private readonly ILogger<MatchController> _logger;
        private static string ErrorMessage(string message) => $"{{\"message\": \"{message}\"}}";

        public MatchController(ILogger<MatchController> logger, CardApiContext db)
        {
            DB = db;
            _logger = logger;
        }
        [HttpGet("{Id}")]
        public Match? Get(Guid Id) => DB.matches.Find(Id);

        [HttpPost]
        public IActionResult MakeMatch([FromBody] Guid player1)
        {
            Console.WriteLine(player1);
            //check is user excists
        

            Match[] result = DB.matches.Where(x => x.Player1 == player1 || x.Player2 == player1).ToArray();
            if (result.Count() > 0)
                return BadRequest(ErrorMessage("player is already in a match"));

            Match newMatch = new Match(player1);
            DB.matches.Add(newMatch);
            DB.SaveChanges();
            return Ok(newMatch.Id);
        }
        [HttpPatch("join/{MatchId}")]
        public IActionResult JoinMatch(Guid MatchId, [FromBody] Guid player)
        {
            Console.WriteLine(player);
            Console.WriteLine(MatchId);
            Match[] result = DB.matches.Where(x => x.Player1 == player || x.Player2 == player).ToArray();
            Match? match = DB.matches.Find(MatchId);



            
            if (match == null)
                return StatusCode(404);
            if (match.Player1 == player)
                return StatusCode(200);    
            if (match.Player2 == player)
                return StatusCode(200);
            if (result.Count() > 0)
                return StatusCode(304,ErrorMessage("player is already in a match"));
          
            if (match.Player2 != null)
                return StatusCode(304);

            match.Player2 = player;
            DB.matches.Update(match);
            DB.SaveChanges();
            return StatusCode(200);
        }

       






        //developer / admin commands

        [HttpGet]
        public IEnumerable<Match> Get()
        {
            return DB.matches.ToArray();

        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            Match? match = DB.matches.Find(id);
            if (match != null)
            {
                DB.matches.Remove(match);
                DB.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
