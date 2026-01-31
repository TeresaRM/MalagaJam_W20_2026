using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    [SerializeField] string Back;


    public void GoBack()
    {
        SceneManager.LoadScene(Back);
    }

}
