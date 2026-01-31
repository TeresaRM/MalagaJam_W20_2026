using UnityEngine;
using UnityEngine.UI;

public class SelectorManager : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;

    private void Start()
    {
        level2Button.interactable = false;
        level3Button.interactable = false;
    }
}
