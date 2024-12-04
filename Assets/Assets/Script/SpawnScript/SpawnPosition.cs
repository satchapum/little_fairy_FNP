using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : Singleton<SpawnPosition>
{
    [SerializeField] List<GameObject> spawnPosition;
    [SerializeField] GameObject playerObject;
    [SerializeField] OVRPlayerController playerOVR;
    [SerializeField] GameObject targetPostion;

    int timeTosetPosition = 0;

    private void Start()
    {
        setPosition();
    }

    public void setPosition()
    {
        int currentMiniGame = GameManager.Instance.currentPlayerMiniGame;
        
        for (int numberOfSpawnPoint = 0; numberOfSpawnPoint < spawnPosition.Count; numberOfSpawnPoint++)
        {
            GameObject positionNumber = spawnPosition[numberOfSpawnPoint];
            int positionMiniGame = positionNumber.GetComponent<SpawnPointNumber>().spawnPointNumber;

            if (currentMiniGame == positionMiniGame)
            {
                targetPostion = positionNumber;
                playerOVR.enabled = false;
                playerObject.transform.position = positionNumber.transform.position;
                playerObject.transform.rotation = positionNumber.transform.rotation;
                playerOVR.enabled = true;
            }
        }
    }
    void Update() 
    {
        if (((playerObject.transform.position.x != targetPostion.transform.position.x) && (playerObject.transform.position.y != targetPostion.transform.position.y)) && timeTosetPosition < 1) 
        {
            timeTosetPosition++;
            playerOVR.enabled = false;
            playerObject.transform.position = targetPostion.transform.position;
            playerObject.transform.rotation = targetPostion.transform.rotation;
            playerOVR.enabled = true;
        }
    }
}
