using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> miniGameList;
    
    private void Start()
    {

        for (int numberOfMiniGame = 0; numberOfMiniGame < miniGameList.Count; numberOfMiniGame++)
        {
            MiniGameNumber miniGameNumber =  miniGameList[numberOfMiniGame].GetComponent<MiniGameNumber>();
            if (miniGameNumber.numberOfMiniGame == GameManager.Instance.currentPlayerMiniGame)
            {
                miniGameList[numberOfMiniGame].SetActive(true);
            }
            else
            {
                miniGameList[numberOfMiniGame].SetActive(false);
            }
        }
    }

}
