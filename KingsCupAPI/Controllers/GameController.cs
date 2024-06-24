using KingsCupGame.Models;
using KingsCupGame.Services;
using Microsoft.AspNetCore.Mvc;

namespace KingsCupGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController()
        {
            _gameService = new GameService();
        }

        [HttpGet("draw")]
        public ActionResult<Card> DrawCard()
        {
            var card = _gameService.DrawCard();
            if (card == null)
            {
                return NotFound("The deck is empty.");
            }

            return Ok(card);
        }

        [HttpGet("rule/{rank}")]
        public ActionResult<string> GetRule(string rank)
        {
            var rule = _gameService.GetRule(rank);
            if (rule == null)
            {
                return NotFound("No rule found for this rank.");
            }

            return Ok(rule);
        }

        [HttpGet("deck")]
        public ActionResult<IEnumerable<Card>> GetDeck()
        {
            return Ok(_gameService.GetDeck());
        }
    }
}
