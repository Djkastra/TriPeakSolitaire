using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TriPeakSolitaire
{
    public class LeaderboardPanel : MonoBehaviour
    {
        [SerializeField] private LeaderboardItem leaderboardItemPrefab;
        [SerializeField] private Button closeButton;
        [SerializeField] private Transform viewContent;
        private List<LeaderboardItem> leaderboardItems = new List<LeaderboardItem>();

        private void OnEnable()
        {
            closeButton.onClick.AddListener(OnCloseButtonClicked);
        }

        private void OnCloseButtonClicked()
        {
            Reset();
        }

        private void OnDisable()
        {
            closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        }

        public void Populate(LeaderboardDto leaderboardDto)
        {
            foreach (var item in leaderboardDto.LeaderboardItems)
            {
                var leaderboardItem = Instantiate(leaderboardItemPrefab, viewContent);
                leaderboardItem.Populate(item);
                leaderboardItems.Add(leaderboardItem);
            }
        }
        
        private void Reset()
        {
            gameObject.SetActive(false);
            foreach (var item in leaderboardItems)
            {
                Destroy(item.gameObject);
            }
            leaderboardItems.Clear();
        }
    }
}