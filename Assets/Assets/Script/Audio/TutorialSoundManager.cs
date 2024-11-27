using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Audio;
public class TutorialSoundManager : Singleton<TutorialSoundManager>
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] int currentNumberOfSoundTrack = 0;


    [Header("BedroomAwakeSound")]
    [SerializeField] List<AudioClip> whenAwakeTutorialSound;

    [Header("ArrangeBookTutorialSound")]
    [SerializeField] List<AudioClip> arrangeBookTutorialSound;

    [Header("ArrangeFruitTutorialSound")]
    [SerializeField] List<AudioClip> arrangeFruitTutorialSound;

    [Header("EatGruelTutorialSound")]
    [SerializeField] List<AudioClip> eatGruelTutorialSound;

    [Header("DishWashTutorialSound")]
    [SerializeField] List<AudioClip> dishWashTutorialSound;

    [Header("wasteSortingTutorialSound")]
    [SerializeField] List<AudioClip> wasteSortingTutorialSound;


    public void CheckCurrentScene()
    {
        if (SceneManager.GetActiveScene().name == "Bedroom")
        {
            BedRoomWhenAwakeTutorialAudio();
        }
        else if (SceneManager.GetActiveScene().name == "Bedroom" + GameManager.Instance.currentGameLevel)
        {
            BedRoomForDoJobTutorial();
        }
        else if (SceneManager.GetActiveScene().name == "Kitchen" + GameManager.Instance.currentGameLevel)
        {
            KitchenForDoJobTutorial();
        }
        else if (SceneManager.GetActiveScene().name == "Livingroom" + GameManager.Instance.currentGameLevel)
        {
            LivingroomForDoJobTutorial();
        }

    }

    void BedRoomWhenAwakeTutorialAudio()
    {
        soundSource.clip = whenAwakeTutorialSound[currentNumberOfSoundTrack];
        soundSource.Play();
        currentNumberOfSoundTrack++;
        if (currentNumberOfSoundTrack >= whenAwakeTutorialSound.Count)
        {
            currentNumberOfSoundTrack = 0;
        }
    }

    void BedRoomForDoJobTutorial()
    {
        soundSource.clip = arrangeBookTutorialSound[currentNumberOfSoundTrack];
        soundSource.Play();
        currentNumberOfSoundTrack++;
        if (currentNumberOfSoundTrack >= arrangeBookTutorialSound.Count)
        {
            currentNumberOfSoundTrack = 0;
        }
    }

    public void KitchenForDoJobTutorial()
    {
        if (GameManager.Instance.currentPlayerMiniGame == 2)
        {
            soundSource.clip = arrangeFruitTutorialSound[currentNumberOfSoundTrack];
            soundSource.Play();
            currentNumberOfSoundTrack++;
            if (currentNumberOfSoundTrack >= arrangeFruitTutorialSound.Count)
            {
                currentNumberOfSoundTrack = 0;
            }
        }
        else if (GameManager.Instance.currentPlayerMiniGame == 3)
        {
            soundSource.clip = eatGruelTutorialSound[currentNumberOfSoundTrack];
            soundSource.Play();
            currentNumberOfSoundTrack++;
            if (currentNumberOfSoundTrack >= eatGruelTutorialSound.Count)
            {
                currentNumberOfSoundTrack = 0;
            }
        }
        else if (GameManager.Instance.currentPlayerMiniGame == 4)
        {
            soundSource.clip = dishWashTutorialSound[currentNumberOfSoundTrack];
            soundSource.Play();
            currentNumberOfSoundTrack++;
            if (currentNumberOfSoundTrack >= dishWashTutorialSound.Count)
            {
                currentNumberOfSoundTrack = 0;
            }
        }
    }

    void LivingroomForDoJobTutorial()
    {
        soundSource.clip = wasteSortingTutorialSound[currentNumberOfSoundTrack];
        soundSource.Play();
        currentNumberOfSoundTrack++;
        if (currentNumberOfSoundTrack >= wasteSortingTutorialSound.Count)
        {
            currentNumberOfSoundTrack = 0;
        }
    }
}
