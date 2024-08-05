/*
 * Create Cards for the game
 */
using System.Collections.Generic;
using UnityEngine;

namespace TriPeakSolitaire
{
    public class CardDeckFactory : ICardDeckFactory
    {
        private GameObject cardPrefab;
        
        public CardDeckFactory(GameObject cardPrefab)
        {
            this.cardPrefab = cardPrefab;
        }
        
        public Dictionary<CardValues, Card> CreateCards(Sprite[] cardFaces)
        {
            var cards = new Dictionary<CardValues, Card>();
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    var cardValues = new CardValues(i, j + 1);
                    var card = Card.CreateNewCard(cardPrefab);
                    card.UpdateCardUi(cardFaces[i * 13 + j], cardValues, cardFaces[52]);
                    cards.Add(cardValues, card);
                }
            }
            return cards;
        }
    }
}