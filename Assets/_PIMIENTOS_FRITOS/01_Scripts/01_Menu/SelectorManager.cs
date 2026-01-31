using UnityEngine;
using UnityEngine.UI;

public class SelectorManager : MonoBehaviour
{
    public static SelectorManager selectorManagerInstance;

    [Header("Door Settings")]
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Image door2Image;
    [SerializeField] private Image door3Image;

    private void Awake()
    {
        selectorManagerInstance = this;
    }

    private void Start()
    {
        level2Button.interactable = false;
        level3Button.interactable = false;
    }


}
