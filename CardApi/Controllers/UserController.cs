using CardApi.Models.Cards;
using CardApi.Models;
using Microsoft.AspNetCore.Mvc;
using CardApi.Models.Account;

namespace CardApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {


        private readonly CardApiContext DB;


        private readonly ILogger<CardController> _logger;

        public UserController(ILogger<CardController> logger, CardApiContext db)
        {
            DB = db;
            _logger = logger;



            DB.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return DB.Users.ToArray();
        }

        [HttpGet("{Id}")]
        public User Get(Guid Id)
        {
            User? user = DB.Users.Find(Id);
            if (user != null)
            {
                return user;
            }

            return null;
        }



        [HttpPost]
        public IActionResult AddCard(User user)
        {

            DB.Add(new User() { UserName = user.UserName });
            DB.SaveChanges();
            return Ok();
        }

        [HttpDelete("{Id}")]

        public IActionResult DeleteCard(Guid Id)
        {
            User? user = DB.Users.Find(Id);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                DB.Users.Remove(user);
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


