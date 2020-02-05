using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Card
    {
        public string CardRank;
        public string Suit;
        public int Value;

        public Card(string rank, string cardSuit, int cardVal)
        {
            CardRank = rank;
            Suit = cardSuit;
            Value = cardVal;
        }
    }

    class DeckOfCards
    {
        public List<Card> cards;

        public DeckOfCards()
        {
            cards = new List<Card>();
            int[] values = {1,2,3,4,5,6,7,8,9,10,11,12,13};
            string[] ranks = {"Ace", "Jack", "Queen", "King"};
            string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
            foreach(string suit in suits)
            {
                foreach(int value in values)
                {
                    string rank = value.ToString();
                    if(value == 1)
                    {
                        Card newCard = new Card(ranks[0], suit, value);
                        cards.Add(newCard);
                    }
                    else if(value == 11)
                    {
                        Card newCard = new Card(ranks[1], suit, value);
                        cards.Add(newCard);
                    }
                    else if(value == 12)
                    {
                        Card newCard = new Card(ranks[2], suit, value);
                        cards.Add(newCard);
                    }
                    else if(value == 13)
                    {
                        Card newCard = new Card(ranks[3], suit, value);
                        cards.Add(newCard);
                    }
                    else
                    {
                        Card newCard = new Card(rank, suit, value);
                        cards.Add(newCard);
                    }
                }
            }
        }
    
        public List<Card> Shuffle()
        {
            Random rand = new Random();
            for(int i = 0; i < cards.Count; i++)
            {
                int x = rand.Next(0,52);
                Card temp = cards[i];
                cards[i] = cards[x];
                cards[x] = temp;
            }
            return cards;
        }
    
        public Card Deal()
        {
            Card topMost = cards[0];
            cards.RemoveAt(0);
            return topMost;
        }

        public List<Card> Reset()
        {
            cards = new DeckOfCards().cards;
            return cards;
        }
    }

    class Player
    {
        public string Name;
        public List<Card> Hand;
        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public Card Draw(DeckOfCards deck)
        {
            Card topCard = deck.Deal();
            Hand.Add(topCard);
            return topCard;
        }

        public Card Discard(int index)
        {
            if(index < Hand.Count)
            {
                Card theCard = Hand[index];
                Hand.Remove(theCard);
                return theCard;
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards newDeck = new DeckOfCards();
            Player player1 = new Player("Phil Ivey");
            // for(int i = 0; i < 30; i++)
            // {
            //     newDeck.Deal();
            // }
            // foreach(Card card in newDeck.cards)
            // {
            //     Console.Write($"{card.CardRank} of {card.Suit}  ");
            // }
            // newDeck.Reset();
            newDeck.Shuffle();
            foreach(Card card in newDeck.cards)
            {
                Console.Write($"{card.CardRank} of {card.Suit}  ");
            }
            for(int i = 0; i < 4; i++)
            {
                player1.Draw(newDeck);
            }
            Console.WriteLine($"\n\n{player1.Name}'s hand:\n***********");
            foreach(Card card in player1.Hand)
            {
                Console.WriteLine($"{card.CardRank} of {card.Suit}  ");
            }
            Console.WriteLine("\n\n");
            foreach(Card card in newDeck.cards)
            {
                Console.Write($"{card.CardRank} of {card.Suit}  ");
            }
            player1.Discard(2);
            Console.WriteLine($"\n\n{player1.Name}'s hand now:\n***********");
            foreach(Card card in player1.Hand)
            {
                Console.WriteLine($"{card.CardRank} of {card.Suit}  ");
            }
        }
    }
}
