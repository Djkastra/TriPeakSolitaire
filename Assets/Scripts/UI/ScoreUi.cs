using TMPro;
using UnityEngine;

namespace TriPeakSolitaire
{
    public class ScoreUi : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text highestScoreText;
        
        private void Start()
        {
            ResetScore();
            highestScoreText.text = $"Top Score: {GetHighestScore()}";
        }
        
        public void SetScore(int score)
        {
            scoreText.text = $"Score: {score}";
            var highestScore = GetHighestScore();
            if (score > highestScore)
            {
                SetHighestScore(score);
                highestScoreText.text = $"Top Score: {score}";
            }
        }
        
        private void ResetScore()
        {
            scoreText.text = $"Score: 0";
        }
        
        private int GetHighestScore()
        {
            return ReadWriter.GetInt(GameConstant.HIGHEST_SCORE);
        }
        
        private void SetHighestScore(int score)
        {
            ReadWriter.SetInt(GameConstant.HIGHEST_SCORE, score);
        }
    }
}
