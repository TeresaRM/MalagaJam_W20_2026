using UnityEngine;
using UnityEngine.UI;

public class SelectorManager : MonoBehaviour
{
    public static SelectorManager selectorManagerInstance;

    [Header("Door Settings")]
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;

    private void Awake() => selectorManagerInstance = this;

    private void Start() => LockAllLevelsExceptFirst();

    public void LockAllLevelsExceptFirst()
    {
        level2Button.interactable = false;
        level3Button.interactable = false;
    }

    public void UnlockLevel2() => level2Button.interactable = true;

    public void UnlockLevel3() => level3Button.interactable = true;
}