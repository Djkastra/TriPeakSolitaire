using System.Collections.Generic;

namespace TriPeakSolitaire
{
    public class GameScore
    {
        public GameScore()
        {
            Reset();
        }

        public int CurrentScore { get; private set; } = 0;

        public void Reset()
        {
            CurrentScore = 0;
        }

        public void Increase()
        {
            CurrentScore++;
        }
    }
}