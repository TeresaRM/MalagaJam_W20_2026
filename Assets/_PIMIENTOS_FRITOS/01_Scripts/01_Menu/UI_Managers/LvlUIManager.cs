using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlUIManager : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private string leaderboardKey;
    [SerializeField] private float minPointsRequiredToCompleteLevel;

    [Header("Fade Settings")]
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private float initialFadeDuration;

    [Header("Saving Settings")]
    [SerializeField] private CanvasGroup resultsContainerCanvasGroup;
    [SerializeField] private TextMeshProUGUI playerScoreTxt;
    [SerializeField] private TextMeshProUGUI playerTimeTxt;
    [SerializeField] private TMP_InputField nameInputField;

    private void Start() => fadeCanvasGroup.DOFade(0, initialFadeDuration);

    public void OpenResultsPanel()
    {

        fadeCanvasGroup.DOFade(1, initialFadeDuration).OnComplete(() =>
        {
            resultsContainerCanvasGroup.DOFade(1, initialFadeDuration)
          .OnComplete(() =>
          {
              resultsContainerCanvasGroup.blocksRaycasts = true;
              resultsContainerCanvasGroup.interactable = true;
              SetPlayerScore();
              SetTimeTaken();
          });
        });

    }

    private void SetPlayerScore()
    {
        if (PointsManager.Instance != null)
            playerScoreTxt.text = "Puntuaci�n: " + (int)PointsManager.Instance.GetTotalPoints();
    }

    private void SetTimeTaken()
    {
        if (PointsManager.Instance != null)
        {
            int totalSeconds = (int)PointsManager.Instance.time;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            string formattedTime = $"Tiempo: {minutes:00}:{seconds:00}";
            playerTimeTxt.text = formattedTime;
        }
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

    public void ReturnButton()
    {
        if (SelectorManager.selectorManagerInstance != null && PointsManager.Instance.totalPoints >= minPointsRequiredToCompleteLevel)
            SelectorManager.selectorManagerInstance.UnlockLevel2();

        StartCoroutine(ActionsAfterLeavingLevel());
        LeaveLevelFadeOut();
    }

    private IEnumerator ActionsAfterLeavingLevel()
    {
        yield return new WaitForSeconds(initialFadeDuration);
        SceneManager.LoadScene(1);      // return to the level selector
    }

    private void LeaveLevelFadeOut() => fadeCanvasGroup.DOFade(1, initialFadeDuration);
}