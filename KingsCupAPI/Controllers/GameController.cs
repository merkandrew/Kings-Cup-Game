using KingsCupGame.Models;
using KingsCupGame.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KingsCupGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        #region GET Requests

        [HttpGet("draw")]
        public ActionResult<Card> DrawCard()
        {
            var card = _gameService.DrawCard();
            if (card == null)
            {
                return NotFound("No more cards in the deck.");
            }
            return Ok(card);
        }

        [HttpGet("deck")]
        public ActionResult<IEnumerable<Card>> GetDeck()
        {
            return Ok(_gameService.GetDeck());
        }

        [HttpGet("rule/{rank}")]
        public ActionResult<string> GetRule(string rank)
        {
            var rule = _gameService.GetRule(rank);
            if (rule == null)
            {
                return NotFound("Rule not found.");
            }
            return Ok(rule);
        }

        [HttpGet("rules")]
        public ActionResult<Dictionary<string, string>> GetAllRules()
        {
            return Ok(_gameService.GetAllRules());
        }

        [HttpGet("players")]
        public ActionResult<IEnumerable<Player>> GetPlayers()
        {
            return Ok(_gameService.GetPlayers());
        }

        [HttpGet("history")]
        public ActionResult<IEnumerable<Card>> GetCardDrawHistory()
        {
            return Ok(_gameService.GetCardDrawHistory());
        }

        [HttpGet("player/{name}")]
        public ActionResult<Player> GetPlayer(string name)
        {
            var player = _gameService.GetPlayers().FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                return NotFound("Player not found.");
            }
            return Ok(player);
        }

        [HttpGet("state")]
        public ActionResult GetGameState()
        {
            var state = new
            {
                Players = _gameService.GetPlayers(),
                Deck = _gameService.GetDeck(),
                CardDrawHistory = _gameService.GetCardDrawHistory(),
            };
            return Ok(state);
        }

        [HttpGet("statistics")]
        public ActionResult GetStatistics()
        {
            var mostDrawnCard = _gameService.GetCardDrawHistory()
                .GroupBy(card => card)
                .OrderByDescending(group => group.Count())
                .Select(group => new { Card = group.Key, Count = group.Count() })
                .FirstOrDefault();

            var statistics = new
            {
                MostDrawnCard = mostDrawnCard,
                TotalCardsDrawn = _gameService.GetCardDrawHistory().Count()
            };
            return Ok(statistics);
        }

        [HttpGet("history/{playerName}")]
        public ActionResult GetPlayerHistory(string playerName)
        {
            var playerActions = _gameService.GetPlayerActions(playerName);
            if (playerActions == null)
            {
                return NotFound("Player not found or no actions recorded.");
            }
            return Ok(playerActions);
        }

        #endregion

        #region POST Requests

        [HttpPost("player")]
        public ActionResult AddPlayer([FromBody] string name)
        {
            _gameService.AddPlayer(name);
            return Ok();
        }

        [HttpPost("reset")]
        public ActionResult ResetGame()
        {
            _gameService.ResetGame();
            return Ok();
        }

        [HttpPost("config")]
        public ActionResult ConfigureGame([FromBody] GameConfig config)
        {
            _gameService.ConfigureGame(config);
            return Ok();
        }

        #endregion

        #region PUT Requests

        [HttpPut("player/{oldName}")]
        public ActionResult UpdatePlayer(string oldName, [FromBody] string newName)
        {
            var player = _gameService.GetPlayers().FirstOrDefault(p => p.Name == oldName);
            if (player == null)
            {
                return NotFound("Player not found.");
            }
            _gameService.RemovePlayer(oldName);
            _gameService.AddPlayer(newName);
            return Ok();
        }

        #endregion

        #region DELETE Requests

        [HttpDelete("player/{name}")]
        public ActionResult RemovePlayer(string name)
        {
            _gameService.RemovePlayer(name);
            return Ok();
        }

        #endregion
    }
}
