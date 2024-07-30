using DG.Tweening;
using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FadeScene : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private Tween fadeTween;

    public void DoFadeAndChangeScene()
    {
        StartCoroutine(DoWhenFade());
    }

    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });
    }
    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = canvasGroup.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

    private IEnumerator DoWhenFade()
    {
        FadeIn(1f);
        yield return new WaitForSeconds(3f);
        //
        // Add sound here
        //
        FadeOut(1f);
        SceneManager.LoadScene("Bedroom");
    }


}
