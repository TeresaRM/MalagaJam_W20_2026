using UnityEngine;
using LootLocker.Requests;

public class LootLockerLeaderboardManager : MonoBehaviour
{
    public static LootLockerLeaderboardManager leaderboardManagerInstance;

    private void Awake()
    {
        if (leaderboardManagerInstance == null)
        {
            leaderboardManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void GetTopLeaderboardEntries(string leaderboardKey, System.Action<string> onLeaderboardRetrieved)
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, (leaderboardData) =>
        {
            string leaderboardText = "";

            if (leaderboardData == null) { Debug.LogError("Leaderboard response is null."); return; }

            if (!leaderboardData.success) { Debug.LogError($"Failed to get leaderboard data: {leaderboardData.errorData.ToString()}"); return; }

            if (leaderboardData.items == null || leaderboardData.items.Length == 0)
            {
                leaderboardText = "No Scores Available";
                onLeaderboardRetrieved?.Invoke(leaderboardText);
            }
            else if (leaderboardData.success && leaderboardData.items.Length > 0)
            {
                foreach (var entry in leaderboardData.items) leaderboardText += $"{entry.rank}. {entry.player.name} - {entry.score}\n";
                onLeaderboardRetrieved?.Invoke(leaderboardText);
            }
        });
    }

    public void SubmitNewEntryToLeaderboard(string leaderboardKey, string playerName, int score)
    {
        LootLockerSDKManager.SetPlayerName(playerName, (nameResponse) =>
        {
            if (nameResponse.success)
            {
                LootLockerSDKManager.SubmitScore(playerName, score, leaderboardKey, (scoreResponse) =>
                {
                    if (!scoreResponse.success) Debug.LogError("Failed to submit score. Error: " + scoreResponse.errorData.ToString());
                });
            }
            else Debug.LogError("Failed to set player name. Error: " + nameResponse.errorData.ToString());
        });
    }
}