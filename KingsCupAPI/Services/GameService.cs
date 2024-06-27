using KingsCupGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingsCupGame.Services
{
    public class GameService
    {
        private List<Card> deck = new List<Card>();
        private Dictionary<string, string> rules;
        private List<Player> players = new List<Player>();
        private List<Card> cardDrawHistory = new List<Card>();
        private List<PlayerAction> playerActions = new List<PlayerAction>();
        private GameConfig gameConfig;

        public GameService()
        {
            rules = new Dictionary<string, string>
            {
                { "A", "Waterfall: Everyone drinks. You can only stop when the person before you stops." },
                { "2", "You: Choose someone to drink." },
                { "3", "Me: You drink." },
                { "4", "Floor: Last person to touch the floor drinks." },
                { "5", "Guys: All guys drink." },
                { "6", "Chicks: All girls drink." },
                { "7", "Heaven: Last person to raise their hand drinks." },
                { "8", "Mate: Choose a mate. Your mate drinks whenever you drink." },
                { "9", "Rhyme: Say a word. The next person has to say a word that rhymes. The first who fails drinks." },
                { "10", "Categories: Pick a category. The next person has to say something in that category. The first who fails drinks." },
                { "J", "Never Have I Ever: Say something you’ve never done. Everyone who has done it drinks." },
                { "Q", "Question Master: You become the Question Master. Anyone who answers your questions has to drink." },
                { "K", "King's Cup: Pour some of your drink into the King's Cup. The person who draws the fourth King drinks the King's Cup." }
            };

            InitializeDeck();
        }

        private void InitializeDeck()
        {
            deck.Clear();
            var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            var ranks = new[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(new Card { Suit = suit, Rank = rank });
                }
            }

            cardDrawHistory.Clear();
        }

        public Card? DrawCard()
        {
            if (deck.Count == 0) return null;

            var random = new Random();
            var index = random.Next(deck.Count);
            var drawnCard = deck[index];
            deck.RemoveAt(index);
            cardDrawHistory.Add(drawnCard);

            return drawnCard;
        }

        public IEnumerable<Card> GetDeck()
        {
            return deck;
        }

        public string? GetRule(string rank)
        {
            rules.TryGetValue(rank, out var rule);
            return rule;
        }

        public Dictionary<string, string> GetAllRules()
        {
            return rules;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return players;
        }

        public void AddPlayer(string name)
        {
            if (gameConfig != null && !gameConfig.AllowDuplicates && players.Any(p => p.Name == name))
            {
                throw new InvalidOperationException("Duplicate players are not allowed.");
            }

            if (gameConfig != null && players.Count >= gameConfig.PlayerLimit)
            {
                throw new InvalidOperationException("Player limit reached.");
            }

            players.Add(new Player { Name = name });
        }

        public void RemovePlayer(string name)
        {
            var player = players.FirstOrDefault(p => p.Name == name);
            if (player != null)
            {
                players.Remove(player);
            }
        }

        public void ResetGame()
        {
            players.Clear();
            cardDrawHistory.Clear();
            playerActions.Clear();
            InitializeDeck();
        }

        public void ConfigureGame(GameConfig config)
        {
            gameConfig = config;

            if (config.CustomRules != null)
            {
                foreach (var rule in config.CustomRules)
                {
                    rules[rule.Key] = rule.Value;
                }
            }
        }

        public IEnumerable<Card> GetCardDrawHistory()
        {
            return cardDrawHistory;
        }

        public List<PlayerAction> GetPlayerActions(string playerName)
        {
            return playerActions.Where(pa => pa.PlayerName == playerName).ToList();
        }
    }
}
