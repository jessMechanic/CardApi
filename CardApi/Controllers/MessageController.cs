using CardApi.Models;
using CardApi.Models.Account;
using CardApi.Models.Cards;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardApi.Controllers
{
    [ApiController]
    [Route("messages")]
    public class MessageController : ControllerBase
    {
        public CardApiContext DB { get; private set; }
        private ILogger<CardController> _logger;
        public MessageController(ILogger<CardController> logger, CardApiContext db)
        {
            DB = db;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return DB.Messages.Include(m => m.Sender);
        }


        [HttpPost("/user/{userId}/messages")]
        public IActionResult AddCard(Message message, Guid userId)
        {
            if (message == null)
            {
                return BadRequest();
            }
            if (message.Body == null || message.Title == null)
            {
                return BadRequest();
            }

            if (message.Body.Length > 600 || message.Title.Length > 200)
            {
                return BadRequest();
            }

            User sender = DB.Users.Find(userId);
            if (sender == null)
            {
                return NotFound();
            }

            DB.Messages.Add(new Message() { Body = message.Body, Title = message.Title, Sender = sender,TimeStap = DateTime.Now});
            DB.SaveChanges();
            return Ok();
        }

    }
}
