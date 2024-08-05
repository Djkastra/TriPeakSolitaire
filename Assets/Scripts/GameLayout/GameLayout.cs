/*
 * Responsible for setting up the game layout, dealing cards to tableau, setting up deck and waste pile.
 */
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TriPeakSolitaire
{
    public class GameLayout
    {
        private readonly List<Transform> tableauPositions;
        private readonly List<Card> deckCards;
        private readonly List<Card> removedCardFromTableau = new List<Card>();
        private readonly Stack<Card> wastePile = new Stack<Card>();
        private readonly List<Card> tableauCards = new List<Card>();

        private Transform wastePosition;
        private Transform deckPosition;
        
        public GameLayout(List<Transform> tableauPositions, CardDeck cardDeck)
        {
            this.tableauPositions = tableauPositions;
            deckCards = cardDeck.GetAllCards();
            DealCards();
        }
        
        private void DealCards()
        {
            for (int i = 0; i < 18; i++)
            {
                var card = deckCards[i];
                card.transform.position = tableauPositions[i].position;
                card.IsFaceUp = false;
                card.UpdateSprite();
                tableauCards.Add(card);
            }
            for (int i = 18; i < 28; i++)
            {
                var card = deckCards[i];
                card.transform.position = tableauPositions[i].position;
                card.IsFaceUp = true;
                card.UpdateSprite();
                tableauCards.Add(card);
            }
            deckCards.RemoveRange(0, 28);
        }

        public void SetDeck(Transform wastePosition, Transform deckPosition)
        {
            this.wastePosition = wastePosition;
            this.deckPosition = deckPosition;
            foreach (var card in deckCards)
            {
                card.gameObject.tag = "Deck";
                card.transform.position = deckPosition.position;
            }
            DrawFirstCardFromDeck();
        }

        public void DrawFirstCardFromDeck(Action OnDeckCardOver = null)
        {
            if (deckCards.Count > 0)
            {
                Card topCard = deckCards[0];
                deckCards.RemoveAt(0);
                topCard.transform.position = wastePosition.position;
                topCard.IsFaceUp = true;
                topCard.gameObject.tag = "Waste";
                topCard.UpdateSprite();
                if (wastePile.Count > 0)
                {
                    var existingCard = wastePile.Pop();
                    existingCard.gameObject.SetActive(false);
                }
                wastePile.Push(topCard);
            }
            
            if (deckCards.Count == 0 && NoMoveAvailable())
            {
                // Option to purchase new Deck
                OnDeckCardOver?.Invoke();
            }
        }

        private bool NoMoveAvailable()
        {
            return false;
        }

        public bool CanRemoveCard(Card card)
        {
            Card topWasteCard = wastePile.Peek();
            return Mathf.Abs(card.CardValueFace.Value - topWasteCard.CardValueFace.Value) == 1 || 
                   (card.CardValueFace.Value == (int)CardValue.Ace && topWasteCard.CardValueFace.Value == (int)CardValue.King) || 
                   (card.CardValueFace.Value == (int)CardValue.King && topWasteCard.CardValueFace.Value == (int)CardValue.Ace);
        }

        public void RemoveCard(Card card)
        {
            card.transform.position = wastePosition.position;
            card.IsFaceUp = true;
            var existingCard = wastePile.Pop();
            existingCard.gameObject.SetActive(false);
            removedCardFromTableau.Add(card);
            wastePile.Push(card);
        }

        public List<Card> GetTableauCards()
        {
            return tableauCards;
        }

        public List<Card> GetRemovedCardFromTableau()
        {
            return removedCardFromTableau;
        }

        public void AddNewDeckCard()
        {
            SetDeck(wastePosition, deckPosition);
        }
    }
}