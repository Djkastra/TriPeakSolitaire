using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriPeakSolitaire
{
    public class GameUIHandler : MonoBehaviour
    {
        public Action PurchaseDeckButtonClickEvent;
        
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button purchaseDeckButton;
        [SerializeField] private ScoreUi scoreUi;
        [SerializeField] private GameTimer gameTimer;
        
        public void RegisterEvents()
        {
            newGameButton.onClick.AddListener(OnNewGameButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
            purchaseDeckButton.onClick.AddListener(OnPurchaseDeckButtonClicked);
        }
        
        public void UnregisterEvents()
        {
            newGameButton.onClick.RemoveListener(OnNewGameButtonClicked);
            exitButton.onClick.RemoveListener(OnExitButtonClicked);
            purchaseDeckButton.onClick.RemoveListener(OnPurchaseDeckButtonClicked);
        }

        public void Initialize()
        {
            SetScore(0);
            gameTimer.Initialize();
        }

        public void SetScore(int score)
        {
            scoreUi.SetScore(score);
        }

        private void OnPurchaseDeckButtonClicked()
        {
            PurchaseDeckButtonClickEvent?.Invoke();
        }

        private void OnExitButtonClicked()
        {
            SceneManager.LoadScene("MainScene");
        }

        private void OnNewGameButtonClicked()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void ShowDeckCardOver(Action yesCallback)
        {
            // Show Deck Over UI and Indication To purchase new Deck
            // If Yes, Add New Deck into existing Deck
            // If No, Show Game Over UI
        }
    }
}