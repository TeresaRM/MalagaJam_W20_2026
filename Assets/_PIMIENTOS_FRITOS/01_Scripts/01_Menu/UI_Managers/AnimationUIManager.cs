using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationUIManager : MonoBehaviour
{
    [SerializeField] private Image roomImageComponent;
    [SerializeField] private Image blurImageComponent;
    [SerializeField] private Sprite startImageRoom1;
    [SerializeField] private Sprite startImageRoom2;
    [SerializeField] private Sprite blurImageRoom1;
    [SerializeField] private Sprite blurImageRoom2;
    [SerializeField] private Image handImage;
    [SerializeField] private float startPosY;
    [SerializeField] private float endPosY;
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private float initialFadeDuration;
    [SerializeField] private float crossFadeDuration;
    [SerializeField] private float handMoveDuration;
    [SerializeField] private float waitingTimeWithHand;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void Start()
    {
        Cursor.visible = false;
        handImage.rectTransform.anchoredPosition = new Vector2(handImage.rectTransform.anchoredPosition.x, startPosY);
        Debug.Log(SelectorManager.selectorManagerInstance.currentLevel);
        if (SelectorManager.selectorManagerInstance != null && SelectorManager.selectorManagerInstance.currentLevel == 3)
        {
            if (roomImageComponent != null) roomImageComponent.sprite = startImageRoom1;
            if (blurImageComponent != null) blurImageComponent.sprite = blurImageRoom1;
        }
        else
        {
            if (roomImageComponent != null) roomImageComponent.sprite = startImageRoom2;
            if (blurImageComponent != null) blurImageComponent.sprite = blurImageRoom2;
        }


        fadeCanvasGroup.DOFade(0, initialFadeDuration)
            .OnComplete(() =>
            {
                if (SelectorManager.selectorManagerInstance.currentLevel == 3) ImageCrossFade(blurImageRoom1, crossFadeDuration);
                else ImageCrossFade(blurImageRoom2, crossFadeDuration);
            });
    }

    private void ImageCrossFade(Sprite nextSprite, float duration)
    {
        blurImageComponent.color = new Color(1, 1, 1, 1);
        roomImageComponent.DOFade(0, duration).OnComplete(() => HandAnimation());
    }

    private void HandAnimation()
    {
        handImage.rectTransform.DOAnchorPosY(endPosY, 1f).SetEase(Ease.OutBack)
            .OnStart(() => audioSource.PlayOneShot(audioClip)) 
            .OnComplete(() => StartCoroutine(ActionsAfterAnimation()));
    }

    private IEnumerator ActionsAfterAnimation()
    {
        yield return new WaitForSeconds(waitingTimeWithHand);
        fadeCanvasGroup.DOFade(1, initialFadeDuration)
            .OnComplete(() => {
                SceneManager.LoadScene(SelectorManager.selectorManagerInstance.currentLevel);
                Cursor.visible = true;
            });
    }
}