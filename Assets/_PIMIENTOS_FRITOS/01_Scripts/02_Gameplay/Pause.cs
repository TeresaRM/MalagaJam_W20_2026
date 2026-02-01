using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.B))
        {
            SceneManager.LoadScene(0);
        }
    }
}
