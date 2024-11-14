using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapPusherScript : MonoBehaviour
{
    [SerializeField] GameObject soapCollider;

    public GameObject bubblePar;
    public int numberOfDelay = 1;

    void Start()
    {
        soapCollider.SetActive(false);
        bubblePar.SetActive(false);
    }

    [ContextMenu("PushSoap")]
    public void PushSoap()
    {
        StartCoroutine(SoapShow());
    }

    IEnumerator SoapShow()
    {
        bubblePar.SetActive(true);
        soapCollider.SetActive(true);
        yield return new WaitForSeconds(numberOfDelay);
        bubblePar.SetActive(false);
        soapCollider.SetActive(false);
    }
}
