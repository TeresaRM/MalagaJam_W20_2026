using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string FreeMode;
    [SerializeField] string HistoryMode;
    [SerializeField] string FinalScore;

    public void GoToFreeMode()
    {
        SceneManager.LoadScene(FreeMode);
    }

    public void GoToHistoryMode()
    {
        SceneManager.LoadScene(HistoryMode);
    }
    public void GoToFinalScore()
    {
        SceneManager.LoadScene(FinalScore);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
