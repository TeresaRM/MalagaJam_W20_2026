using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderboardContents;
    [SerializeField] private float rankingFadeDuration;

    public void StartLevel(int level)
    {
        StartCoroutine(ActionsAfterStartAnim(level));
        //LeaveLevelSelector();
    }

    private IEnumerator ActionsAfterStartAnim(int level)
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(level);  // load selected level (lvl 1 = 2, lvl 2 = 3, lvl 3 = 4)
    }

    public void ShowPanel(GameObject container)   // triggered by the ranking buttons
    {
        container.GetComponent<CanvasGroup>().DOFade(1, rankingFadeDuration)
            .OnComplete(() =>
            {
                container.GetComponent<CanvasGroup>().blocksRaycasts = true;
                container.GetComponent<CanvasGroup>().interactable = true;
            });
    }

    public void DisplayLootLockerLeaderboard(string leaderboardKey)
    {
        leaderboardContents.text = "fetching leaderboard...";
        if (LootLockerLeaderboardManager.leaderboardManagerInstance != null)
            LootLockerLeaderboardManager.leaderboardManagerInstance.GetTopLeaderboardEntries(leaderboardKey, (leaderboardText) => { leaderboardContents.text = leaderboardText; });
        else leaderboardContents.text = "error fetching leaderboard";
    }

    public void BackButtonFunction(GameObject container)   // triggered by the back button in the ranking panels
    {
        container.GetComponent<CanvasGroup>().DOFade(0, rankingFadeDuration / 2)
            .OnComplete(() =>
            {
                container.GetComponent<CanvasGroup>().blocksRaycasts = false;
                container.GetComponent<CanvasGroup>().interactable = false;
            });
    }
}