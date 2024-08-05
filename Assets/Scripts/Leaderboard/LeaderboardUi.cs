using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

namespace TriPeakSolitaire
{
    public class LeaderboardUi : MonoBehaviour
    {
        [SerializeField] private Button leaderBoardButton;
        [SerializeField] private TextAsset leaderboardData;
        [SerializeField] private LeaderboardPanel leaderboardPanel;
        private LeaderboardDto leaderboardDto;
        private LeaderboardDriver leaderboardDriver;
        private void Awake()
        {
            leaderBoardButton.onClick.AddListener(OnLeaderboardButtonClicked);
            leaderboardDriver = new LeaderboardDriver();
        }

        private void OnLeaderboardButtonClicked()
        {
            StartCoroutine(leaderboardDriver.GetLeaderboard((response) =>
            {
                if (response.isSuccess)
                {
                    leaderboardDto = JsonConvert.DeserializeObject<LeaderboardDto>(leaderboardData.text);
                    PopulateUi();
                }
            }));
        }

        private void PopulateUi()
        {
            leaderboardPanel.gameObject.SetActive(true);
            leaderboardPanel.Populate(leaderboardDto);
        }

        private void OnDestroy()
        {
            leaderBoardButton.onClick.RemoveListener(OnLeaderboardButtonClicked);
        }
    }
}