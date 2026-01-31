using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string FreeMode;
    [SerializeField] string HistoryMode;
    [SerializeField] string Gallery;
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    private float fadeDuration = 0.5f;

    private void Start() => fadeCanvasGroup.DOFade(0, fadeDuration);

    public void GoToFreeMode() => SceneManager.LoadScene(FreeMode);

    public void GoToHistoryMode()
    {
        StartCoroutine(ActionsAfterStartAnim());
        LeaveMainMenu();
    }

    private IEnumerator ActionsAfterStartAnim()
    {
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(HistoryMode);             // load selected level (lvl 1 = 2, lvl 2 = 3, lvl 3 = 4)
    }

    private void LeaveMainMenu() => fadeCanvasGroup.DOFade(1, fadeDuration);

    public void GoToGallery() => SceneManager.LoadScene(Gallery);

    public void ExitGame()
    {
        StartCoroutine(ActionsAfterQuit());
        LeaveMainMenu();
    }

    private IEnumerator ActionsAfterQuit()
    {
        yield return new WaitForSeconds(fadeDuration);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
    }
#endif
    }
}