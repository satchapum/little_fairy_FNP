using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        else if (SceneManager.GetActiveScene().name == "Garden" + GameManager.Instance.currentGameLevel)
        {
            GardenForDoJobTutorial();
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
        Debug.Log($"Scene: {SceneManager.GetActiveScene().name}, MiniGame: {GameManager.Instance.currentPlayerMiniGame}");

        AudioClip selectedClip = null;

        if (GameManager.Instance.currentPlayerMiniGame == 2)
        {
            Debug.Log("Playing Arrange Fruit Sound");
            selectedClip = arrangeFruitTutorialSound[currentNumberOfSoundTrack];
        }
        else if (GameManager.Instance.currentPlayerMiniGame == 3)
        {
            Debug.Log("Playing Eat Gruel Sound");
            selectedClip = eatGruelTutorialSound[currentNumberOfSoundTrack];
        }
        else if (GameManager.Instance.currentPlayerMiniGame == 4)
        {
            Debug.Log("Playing Dish Wash Sound");
            selectedClip = dishWashTutorialSound[currentNumberOfSoundTrack];
        }
        else
        {
            Debug.LogWarning("Unhandled MiniGame ID: " + GameManager.Instance.currentPlayerMiniGame);
            return;
        }

        if (selectedClip != null)
        {
            soundSource.clip = selectedClip;
            soundSource.Play();
            Debug.Log("Now playing: " + soundSource.clip.name);
            IncrementSoundTrackIndex(selectedClip);
        }
    }

    void IncrementSoundTrackIndex(AudioClip currentClip)
    {
        currentNumberOfSoundTrack++;
        if (currentNumberOfSoundTrack >= currentClip.length)
        {
            currentNumberOfSoundTrack = 0;
        }
    }


    void GardenForDoJobTutorial()
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
