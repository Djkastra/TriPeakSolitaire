using System;
using System.Collections;

namespace TriPeakSolitaire
{
    public interface ILeaderboard
    {
        IEnumerator GetLeaderboard(Action<NetworkResponse> networkResponse);
    }
}