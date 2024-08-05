/*
 * Handle the game play
 */
using System.Collections.Generic;
using UnityEngine;

namespace TriPeakSolitaire
{
    public class GamePlayController : MonoBehaviour
    {
        [SerializeField] private Sprite[] cardFaces;
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private List<Transform> tableauPositions;
        [SerializeField] private Transform wastePosition;
        [SerializeField] private Transform deckPosition;
        [SerializeField] private GameUIHandler uiHandler;
        
        private CardDeck cardDeck;
        private GameLayout gameLayout;
        private GameLogic gameLogic;
        private GameScore gameScore;
        
        private void Awake()
        {
            CreateCardDeck();
            CreateLayout();
            SetGameLogic();
            SetGameScore();
            uiHandler.RegisterEvents();
            uiHandler.Initialize();
        }

        private void OnDestroy()
        {
            uiHandler.UnregisterEvents();
        }

        private void SetGameScore()
        {
            gameScore = new GameScore();
        }

        private void SetGameLogic()
        {
            gameLogic = new GameLogic(gameLayout.GetTableauCards());
        }

        private void CreateLayout()
        {
            gameLayout = new GameLayout(tableauPositions, cardDeck);
            gameLayout.SetDeck(wastePosition, deckPosition);
        }

        private void CreateCardDeck()
        {
            var cardDeckFactory = new CardDeckFactory(cardPrefab);
            cardDeck = new CardDeck(cardDeckFactory, cardFaces);
        }
        
        public bool CanRemoveCard(Card card)
        {
            return gameLayout.CanRemoveCard(card);
        }

        public void RemoveCard(Card card)
        {
            gameScore.Increase();
            uiHandler.SetScore(gameScore.CurrentScore);
            gameLayout.RemoveCard(card);
            gameLogic.CheckForFaceUpCards(gameLayout.GetRemovedCardFromTableau());
        }

        public void DrawCardFromDeck()
        {
            gameScore.Reset();
            uiHandler.SetScore(gameScore.CurrentScore);
            gameLayout.DrawFirstCardFromDeck(OnDeckCardOver: () =>
            {
                uiHandler.ShowDeckCardOver(() =>
                {
                    // Add New Deck to Game Layout
                });
            });
        }
    }
}