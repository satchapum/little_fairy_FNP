using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : Singleton<SpawnPosition>
{
    [SerializeField] List<GameObject> spawnPosition;
    [SerializeField] GameObject playerObject;

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
                /*playerObject.transform.position = positionNumber.transform.position;
                playerObject.transform.rotation = positionNumber.transform.rotation;

                Debug.Log("ChangeposeTo"+ positionNumber.name);*/
                Rigidbody rb = playerObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.MovePosition(positionNumber.transform.position);
                    rb.MoveRotation(positionNumber.transform.rotation);
                }
                else
                {
                    playerObject.transform.position = positionNumber.transform.position;
                    playerObject.transform.rotation = positionNumber.transform.rotation;
                }
            }

            
        }
    }
}
