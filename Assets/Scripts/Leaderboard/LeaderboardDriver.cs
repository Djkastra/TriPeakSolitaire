using System;
using System.Collections;

namespace TriPeakSolitaire
{
    public class LeaderboardDriver : ILeaderboard
    {
        public NetworkResponse NetworkResponse { get; set; }
        
        public IEnumerator GetLeaderboard(Action<NetworkResponse> callback)
        {
            yield return NetworkManager.Instance.StartWebRequest<NetworkResponse>("https://example.com/leaderboard", callback);
        }
    }
}