using System;

namespace DeckOfCards.Models
{
    public class Card
    {
        public string CardRank;
        public string Suit;
        public int Value;

        public Card(string cardSuit, int cardVal)
        {
            Suit = cardSuit;
            Value = cardVal;
            switch(cardVal)
            {
                case 1:
                    CardRank = "Ace";
                    break;
                case 11:
                    CardRank = "Jack";
                    break;
                case 12:
                    CardRank = "Queen";
                    break;
                case 13:
                    CardRank = "King";
                    break;
                default:
                    CardRank = cardVal.ToString();
                    break;
            }
        }

        public string showStats()
        {
            return ($"{CardRank} of {Suit}");
        }
    }
}