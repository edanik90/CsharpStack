using System;
using System.Collections.Generic;
using DeckOfCards.Models;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            newDeck.Shuffle();
            Player player1 = new Player("Phil Ivey");
            // newDeck.Shuffle();
            newDeck.DisplayCards();
            for(int i = 0; i < 4; i++)
            {
                player1.Draw(newDeck);
            }
            player1.DisplayHand();
            // Console.WriteLine("\n\n");
            // newDeck.DisplayCards();
            // player1.Discard(2);
            // player1.DisplayHand();
        }
    }
}
