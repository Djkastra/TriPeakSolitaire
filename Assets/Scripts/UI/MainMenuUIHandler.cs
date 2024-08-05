using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriPeakSolitaire
{
    public class MainMenuUIHandler : MonoBehaviour
    {
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button exitButton;

        private void Start()
        {
            newGameButton.onClick.AddListener(OnNewGameButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnDestroy()
        {
            newGameButton.onClick.RemoveListener(OnNewGameButtonClicked);
            exitButton.onClick.RemoveListener(OnExitButtonClicked);
        }
        
        private void OnExitButtonClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void OnNewGameButtonClicked()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
