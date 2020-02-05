using System;
using System.Collections.Generic;

namespace DeckOfCards.Models
{
    public class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            Reset();
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int idx1 = rand.Next(cards.Count);
                int idx2 = rand.Next(cards.Count);
                Card temp = cards[idx1];
                cards[idx1] = cards[idx2];
                cards[idx2] = temp;
            }
        }

        public Card Deal()
        {
            Card topMost = cards[0];
            cards.RemoveAt(0);
            return topMost;
        }

        public void DisplayCards()
        {
            foreach (Card card in cards)
            {
                Console.Write($"{card.CardRank} of {card.Suit}  ");
            }
        }
        public List<Card> Reset()
        {
            cards = new List<Card>();
            string[] suits = { "Clubs", "Spades", "Hearts", "Diamonds" };
            foreach(string s in suits)
            {
                for (int i = 1; i <= 13; i++)
                {
                    cards.Add(new Card(s,i));
                }
            }
            return cards;
        }
    }
}