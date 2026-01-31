using DG.Tweening;
using DG.Tweening.Core.Easing;
using TMPro;
using UnityEngine;

public class LvlUIManager : MonoBehaviour
{
    [Header("Fade Settings")]
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private float initialFadeDuration;

    [Header("Saving Settings")]
    [SerializeField] private string leaderboardKey;
    [SerializeField] private TextMeshProUGUI finalPlayerScore;
    [SerializeField] private TextMeshProUGUI savedTxt;
    [SerializeField] private TMP_InputField nameInputField;

    private void Start()
    {
        fadeCanvasGroup.DOFade(0, initialFadeDuration);
    }

    public void SubmitPlayerNameAtGameOver()
    {
        string playerName = nameInputField.text.Trim();                                  // obtain player name from TMP input field
        if (playerName == "") playerName = "XXX";                                        // default name if left empty
        playerName = playerName.Length > 20 ? playerName.Substring(0, 20) : playerName;  // cap player name to 20 characters
        SavePlayerScoreAndName(playerName);
    }

    public void SavePlayerScoreAndName(string playerName)                         // triggered when the player submits their name
    {
        if (PointsManager.Instance != null)
        {
            if (LootLockerLeaderboardManager.leaderboardManagerInstance != null)
                LootLockerLeaderboardManager.leaderboardManagerInstance.SubmitNewEntryToLeaderboard(leaderboardKey, playerName, (int)PointsManager.Instance.totalPoints);
        }
    }
}