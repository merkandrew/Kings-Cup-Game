using KingsCupGame.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KingsCupGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        private readonly GameService _gameService;

        public WelcomeController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public ActionResult<string> GetWelcomeMessage()
        {
            var message = "Welcome to the King's Cup Game API!";
            return Ok(message);
        }

        [HttpGet("rules")]
        public ActionResult<Dictionary<string, string>> GetRules()
        {
            var rules = _gameService.GetAllRules();
            return Ok(rules);
        }
    }
}
