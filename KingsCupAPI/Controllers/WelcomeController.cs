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

        #region GET Requests

        [HttpGet]
     public ActionResult<string> GetWelcomeMessage()
{
    var message = "Welcome to the King's CupGame API! Here are the rules";
    var rules = @"The basic rules for any game of King’s Cup, whether it’s known as Ring of Fire, Circle of Death, Waterfall or just “Kings”, are essentially the same.

To play king’s cup, players must take turns picking cards, going around the circle clockwise.

Each card in the deck corresponds to a specific action, which we’ll go through in the next section.

If you break the chain of cards, you must chug whatever drink is in the king’s cup in the center – we’ll get to that a bit later.

As the concoction of alcohol in the king’s cup may be a very unpleasant mixture, one of the main aims of the game is to avoid breaking the chain!

But even if you do break the chain, this doesn’t end the game. King’s cup only finishes once all the cards are used up.";
    return Ok($"{message}\n{rules}");
}

        [HttpGet("rules")]
        public ActionResult<Dictionary<string, string>> GetRules()
        {
            var rules = _gameService.GetAllRules();
            return Ok(rules);
        }

        #endregion
    }
}
