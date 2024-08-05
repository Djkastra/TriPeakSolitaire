using TMPro;
using TriPeakSolitaire;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardItem : MonoBehaviour
{
    [SerializeField] private TMP_Text rankText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image profileImage;

    public void Populate(LeaderboardItemDto item)
    {
        rankText.text = item.Rank.ToString();
        nameText.text = item.UserData.UserName;
        // Load profile image from URL
    }
}
