using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] PlayerSO playerData;

    [Header("PlayerData")]
    public int currentGameLevel = 1;
    public int currentPlayerMiniGame = 0;
    public int currentStar = 0;

    [Header("MiniGameSetting")]
    public int maxNumberOfMiniGame = 5;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        SetPlayerDataToCurrent();
    }

    public void SetPlayerDataToCurrent()
    {
        currentGameLevel = playerData.currentGameLevel;
        currentStar = playerData.currentStar;
        currentPlayerMiniGame = playerData.currentPlayerMiniGame;
    }

    public void ChangeMiniGame()
    {
        if (currentPlayerMiniGame + 1 > maxNumberOfMiniGame)
        {
            currentPlayerMiniGame = 1;
        }
        else
        {
            currentPlayerMiniGame++;
        }
        SpawnPosition.Instance.setPosition();
    }
}
