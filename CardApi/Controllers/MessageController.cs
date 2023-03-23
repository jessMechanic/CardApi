using CardApi.Models;
using CardApi.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardApi.Controllers
{
    [ApiController]
    [Route("messages")]
    public class MessageController : ControllerBase
    {
        public CardApiContext DB { get; private set; }
        private ILogger<MessageController> _logger;
        public MessageController(ILogger<MessageController> logger, CardApiContext db)
        {
            DB = db;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return DB.Messages.Include(m => m.SenderId);
        }


        [HttpPost("/user/userId/messages")]
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

         

            DB.Messages.Add(new Message() { Body = message.Body, Title = message.Title, SenderId = userId,TimeStap = DateTime.Now});
            DB.SaveChanges();
            return Ok();
        }

    }
}
