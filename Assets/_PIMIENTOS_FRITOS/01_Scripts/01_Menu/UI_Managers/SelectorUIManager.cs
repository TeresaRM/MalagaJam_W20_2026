using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorUIManager : MonoBehaviour
{
    [Header("Back Button")]
    [SerializeField] string backButton;

    [Header("Fade Settings")]
    [SerializeField] private float fadeDuration;
    [SerializeField] private CanvasGroup fadeCanvasGroup;

    [Header("Leaderboard Settings")]
    [SerializeField] private TextMeshProUGUI leaderboardContents;
    [SerializeField] private float rankingFadeDuration;

    private void Start()
    {
        fadeCanvasGroup.DOFade(0, fadeDuration);
    }

    public void StartLevel(int level)
    {
        StartCoroutine(ActionsAfterStartAnim(level));
        LeaveLevelSelector();
    }

    private IEnumerator ActionsAfterStartAnim(int level)
    {
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(level);  // load selected level (lvl 1 = 2, lvl 2 = 3, lvl 3 = 4)
    }

    private void LeaveLevelSelector() => fadeCanvasGroup.DOFade(1, fadeDuration);

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

    public void GoBack()  // triggered by the back button in the selector menu (go back to main menu)
    {
        StartCoroutine(ActionsAfterLeaving());
        LeaveLevelSelector();
    }

    private IEnumerator ActionsAfterLeaving()
    {
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(0);
    }
}