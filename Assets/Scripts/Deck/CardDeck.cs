/*
 * CardDeck.cs
 * Creates Deck of Cards and Suffles them
 */
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TriPeakSolitaire
{
    public class CardDeck
    {
        private Dictionary<CardValues, Card> cards { get; }
        readonly List<Card> deck;

        public CardDeck(ICardDeckFactory factory, Sprite[] cardFaces)
        {
            cards = CreateCard(factory, cardFaces);
            deck = cards.Values.ToList();
            Shuffle();
        }

        private Dictionary<CardValues, Card> CreateCard(ICardDeckFactory factory, Sprite[] cardFaces)
        {
            return factory.CreateCards(cardFaces);
        }

        public void Shuffle()
        {
            for (int i = 0; i < GameConstant.DECK_SIZE; i++)
            {
                SwapCards(i, Random.Range(i, GameConstant.DECK_SIZE));
            }
        }
        
        private void SwapCards(int indexA, int indexB)
        {
            (deck[indexA], deck[indexB]) = (deck[indexB], deck[indexA]);
        }

        public List<Card> GetAllCards()
        {
            return deck;
        }
    }
}