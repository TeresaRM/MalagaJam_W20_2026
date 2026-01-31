using UnityEngine;
using UnityEngine.Events;

public class UIButtonSound : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    [Header("Delay después del sonido")]
    public float delay = 0.2f;

    [Header("Eventos después del sonido")]
    public UnityEvent onAfterSound;

    bool pressed = false;

    public void OnButtonPressed()
    {
        if (pressed) return;
        pressed = true;

        if (audioSource && clickSound)
        {
            audioSource.PlayOneShot(clickSound);
            Invoke(nameof(ExecuteAction), delay);
        }
        else
        {
            ExecuteAction();
        }
    }

    void ExecuteAction()
    {
        onAfterSound?.Invoke();
        pressed = false;
    }
}
