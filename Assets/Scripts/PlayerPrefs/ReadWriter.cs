using UnityEngine;

namespace TriPeakSolitaire
{
    public class ReadWriter
    {
        public static int GetInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public static void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }
    }
}