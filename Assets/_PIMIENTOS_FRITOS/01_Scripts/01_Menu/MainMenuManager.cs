using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string FreeMode;
    [SerializeField] string HistoryMode;
    [SerializeField] string Gallery;

    public void GoToFreeMode()
    {
        SceneManager.LoadScene(FreeMode);
    }

    public void GoToHistoryMode()
    {
        SceneManager.LoadScene(HistoryMode);
    }
    public void GoToGallery()
    {
        SceneManager.LoadScene(Gallery);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
