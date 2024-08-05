namespace TriPeakSolitaire
{
    public class LeaderboardDto
    {
        public LeaderboardItemDto[] LeaderboardItems;
    }
    
    public class LeaderboardItemDto
    {
        public int Rank { get; set; }
        public UserData UserData { get; set; }
    }

    public class UserData
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ProfileUrl { get; set; }
    }
}