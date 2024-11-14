using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapPusherScript : MonoBehaviour
{
    [SerializeField] GameObject soapCollider;

    public ParticleSystem bubblePar;
    public int numberOfDelay = 1;

    [ContextMenu("PushSoap")]
    public void PushSoap()
    {
        StartCoroutine(SoapShow());
    }

    IEnumerator SoapShow()
    {
        bubblePar.Play();
        soapCollider.SetActive(true);
        yield return new WaitForSeconds(numberOfDelay);
        bubblePar.Stop();
        soapCollider.SetActive(false);
    }
}
