using System;
using System.Collections.Generic;

namespace DeckOfCards.Models
{
    public class Player
    {
        public string Name;
        public List<Card> Hand { get; set;}
        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public Card Draw(Deck deck)
        {
            Card topCard = deck.Deal();
            Hand.Add(topCard);
            return topCard;
        }

        public Card Discard(int index)
        {
            if (Hand[index] != null)
            {
                Card theCard = Hand[index];
                Hand.Remove(theCard);
                return theCard;
            }
            return null;
        }

        public void DisplayHand()
        {
            Console.WriteLine($"\n\n{Name}'s hand:\n***********");
            foreach (Card card in Hand)
            {
                Console.WriteLine($"{card.CardRank} of {card.Suit}  ");
            }
        }
    }
}