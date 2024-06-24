using KingsCupGame.Models;
using System;
using System.Collections.Generic;

namespace KingsCupGame.Services
{
    public class GameService
    {
        private static readonly List<Card> deck = new List<Card>();
        private static readonly Dictionary<string, string> rules = new Dictionary<string, string>
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

        public GameService()
        {
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            var ranks = new[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(new Card { Suit = suit, Rank = rank });
                }
            }
        }

        public Card? DrawCard()
        {
            if (deck.Count == 0)
            {
                return null;
            }

            var random = new Random();
            int index = random.Next(deck.Count);
            var card = deck[index];
            deck.RemoveAt(index);

            return card;
        }

        public string? GetRule(string rank)
        {
            return rules.ContainsKey(rank) ? rules[rank] : null;
        }

        public IEnumerable<Card> GetDeck()
        {
            return deck;
        }

        public Dictionary<string, string> GetAllRules()
        {
            return rules;
        }
    }
}
