using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] PlayerSO playerData;

    [Header("PlayerData")]
    public int currentGameLevel = 1;
    public int currentStar = 0;

    private void Awake()
    {
        currentGameLevel = playerData.currentGameLevel;
        currentStar = playerData.currentStar;
    }

    public void SetPlayerDataToCurrent()
    {
        currentGameLevel = playerData.currentGameLevel;
        currentStar = playerData.currentStar;
    }
}
