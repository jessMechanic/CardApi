using CardApi.Models;
using CardApi.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardApi.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly CardApiContext DB;


        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger, CardApiContext db)
        {
            DB = db;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Message> Get(AutchRequest autchRequest)
        {
           throw new NotImplementedException();
        }

        public void RemoveUnussedTokens()
        {
             
        }

    }
}
