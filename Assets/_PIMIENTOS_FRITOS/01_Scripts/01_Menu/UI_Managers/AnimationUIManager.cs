using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationUIManager : MonoBehaviour
{
    [SerializeField] private int sceneToLoadAfterAnimation;
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

    private void Start()
    {
        handImage.rectTransform.anchoredPosition = new Vector2(handImage.rectTransform.anchoredPosition.x, startPosY);
        fadeCanvasGroup.DOFade(0, initialFadeDuration)
            .OnStart(() =>
            {
                //todo
                if (roomImageComponent != null) roomImageComponent.sprite = startImageRoom1;
                if (blurImageComponent != null) blurImageComponent.sprite = blurImageRoom1;
            })
            .OnComplete(() => ImageCrossFade(blurImageRoom1, crossFadeDuration));
    }

    private void ImageCrossFade(Sprite nextSprite, float duration)
    {
        blurImageComponent.color = new Color(1, 1, 1, 1);
        roomImageComponent.DOFade(0, duration).OnComplete(() => HandAnimation());
    }

    private void HandAnimation()
    {
        handImage.rectTransform.DOAnchorPosY(endPosY, 1f).SetEase(Ease.OutBack)
            .OnComplete(() => StartCoroutine(ActionsAfterAnimation()));
    }

    private IEnumerator ActionsAfterAnimation()
    {
        yield return new WaitForSeconds(waitingTimeWithHand);
        fadeCanvasGroup.DOFade(1, initialFadeDuration)
            .OnComplete(() => SceneManager.LoadScene(sceneToLoadAfterAnimation));   // load level 1 (NachoScene with index 3) or level 2
    }
}