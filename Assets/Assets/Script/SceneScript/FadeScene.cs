using DG.Tweening;
using Meta.WitAi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FadeScene : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    //[SerializeField] string sceneToChangeName;
    [SerializeField] PlayerSO playerSO;
    [SerializeField] GameObject poseToGoNextObject;

    public GameObject poseToHide;
    private Tween fadeTween;

    public void DoFadeAndChangeSceneWithLoad()
    {
        StartFade();
    }
    public void DoFadeAndChangeScene()
    {
        GameManager.Instance.ChangeMiniGame();
        StartFade();
    }


    public void DoFadeSaveAndChangeSceneToMainMenu()
    {
        SaveLoadJSON.Instance.SaveGame();

        DoWhenFade("MainmenuScene");

    }

    public void StartFade()
    {
        int currentMiniGame = GameManager.Instance.currentPlayerMiniGame;

        if (currentMiniGame == 1)
        {
            StartCoroutine(DoWhenFade("Bedroom" + GameManager.Instance.currentGameLevel));
        }
        else if (currentMiniGame > 1 && currentMiniGame < 5)
        {
            StartCoroutine(DoWhenFade("Kitchen" + GameManager.Instance.currentGameLevel));
        }
        else if (currentMiniGame > 4 && currentMiniGame < 6)
        {
            StartCoroutine(DoWhenFade("Garden" + GameManager.Instance.currentGameLevel));
        }
    }

    public void DoFadeAndChangeSceneBedRoomMenu()
    { 
        GameManager.Instance.currentPlayerMiniGame = 0;
        
        StartCoroutine(DoWhenMainMenu("Bedroom"));
    }
    public void DoFadeAndChangeSceneBedRoomMenuForNextGameLevel()
    { 
        try
        {
            SceneManager.GetSceneByName("Bedroom" + (GameManager.Instance.currentGameLevel + 1));
            GameManager.Instance.ChangeMiniGame();

            GameManager.Instance.currentPlayerMiniGame = 0;
            StartCoroutine(DoWhenMainMenu("Bedroom"));
        }
        catch
        {
            GameManager.Instance.currentGameLevel = 0;
            GameManager.Instance.currentPlayerMiniGame = 1;
            SaveLoadJSON.Instance.SaveGame();

            GameManager.Instance.currentPlayerMiniGame = 0;
            StartCoroutine(DoWhenMainMenu("Bedroom"));
        }
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

    private IEnumerator DoWhenFade(string sceneName)
    {
        //poseToGoNextObject.SetActive(false);
        FadeIn(1f);
        yield return new WaitForSeconds(3f);
        //
        // Add sound here
        //
        FadeOut(1f);
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }
    private IEnumerator DoWhenMainMenu(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
