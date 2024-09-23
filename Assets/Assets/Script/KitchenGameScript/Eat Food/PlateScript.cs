using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] GameObject plateToMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == plateToMove)
        {
            EatGameManager.Instance.isThisMiniGameFinish = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == plateToMove)
        {
            EatGameManager.Instance.isThisMiniGameFinish = false;
        }
    }
}
