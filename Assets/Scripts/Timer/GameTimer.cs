using TMPro;
using UnityEngine;

namespace TriPeakSolitaire
{
    public class GameTimer : MonoBehaviour
    {
        public TMP_Text timerText;
        private float timeElapsed;
        private bool isRunning;
        private float updateInterval = 1f;
        private float nextUpdateTime;

        public void Initialize()
        {
            timeElapsed = 0f;
            isRunning = true;
            nextUpdateTime = Time.time + updateInterval;
        }

        private void Update()
        {
            if (!isRunning || !(Time.time >= nextUpdateTime))
            {
                return;
            }
            timeElapsed += updateInterval;
            var minutes = Mathf.FloorToInt(timeElapsed / 60);
            var seconds = Mathf.FloorToInt(timeElapsed % 60);
            timerText.text = $"Time: {minutes:D2}:{seconds:D2}";
            nextUpdateTime += updateInterval;
        }

        public void StopTimer()
        {
            isRunning = false;
        }
    }

}