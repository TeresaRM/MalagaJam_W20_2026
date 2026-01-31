using DG.Tweening;
using UnityEngine;

public class LvlUIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private float initialFadeDuration;

    private void Start()
    {
        fadeCanvasGroup.DOFade(0, initialFadeDuration);
    }
}