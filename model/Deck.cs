using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fivecard.model
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = InitializeDeck();
            ShuffleDeck(cards, "firshermans-claw");
        }

        private List<Card> InitializeDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            List<Card> deck = new List<Card>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(new Card { Suit = suit, Rank = rank });
                }
            }

            return deck;
        }

        private void ShuffleDeck(List<Card> deck, string algorithm)
        {

            //FisherYatesShuffle
            Random rand = new Random();

            int n = deck.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                Card temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }

        }


        public List<Card> DealHand(int numCards)
        {
            List<Card> hand = cards.Take(numCards).ToList();
            cards.RemoveRange(0, numCards);
            return hand;
        }

        //testing game loop to check if reinitializing is necessary
        public void cardcount(List<Card> deck)
        {
            Console.WriteLine(deck.Count);
        }
    }
}
