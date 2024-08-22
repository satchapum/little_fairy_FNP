using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadJSON : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] PlayerSO playerSO;
    string saveFilePath;

    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
    }

    public void SaveGame()
    {
        string savePlayerData = JsonUtility.ToJson(playerSO);
        File.WriteAllText(saveFilePath, savePlayerData);

        Debug.Log("Save file created at: " + saveFilePath);
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            playerData = JsonUtility.FromJson<PlayerData>(loadPlayerData);

            Debug.Log("Load game complete! \nPlayer current level : " + playerData.currentGameLevel + "\nPlayer current star : " + playerData.currentStar);

            playerSO.currentGameLevel = playerData.currentGameLevel;
            playerSO.currentStar = playerData.currentStar;
            playerSO.currentPlayerMiniGame = playerData.currentPlayerMiniGame;

            GameManager.Instance.SetPlayerDataToCurrent();
        }
        else
            Debug.Log("There is no save files to load!");

    }

    public void DeleteSaveFile()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);

            Debug.Log("Save file deleted!");
        }
        else
            Debug.Log("There is nothing to delete!");
    }
}
