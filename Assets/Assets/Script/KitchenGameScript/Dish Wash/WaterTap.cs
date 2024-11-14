using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : MonoBehaviour
{
    [Header("CheckCloseOrOpenCollider")]
    [SerializeField] GameObject openCollider;
    [SerializeField] GameObject closeCollider;

    [SerializeField] GameObject waterCollider;
    public ParticleSystem RunningWater;

    public AudioSource openSound;

    private bool isOpen;

    void Start()
    {
        isOpen = false;
        RunningWater.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("testste");
        if (other.gameObject == openCollider)
        {
            Debug.Log("openCollider");
            isOpen = true;
            DoTurnOnWater();
        }
        else if (other.gameObject == closeCollider)
        {
            Debug.Log("Collider");
            isOpen = false;
            DoTurnOnWater();
        }
        else
        {
            isOpen = false;
        }
    }

    void DoTurnOnWater()
    {
        if (isOpen)
        {
            waterCollider.SetActive(true);
            openSound.Play();
            RunningWater.Play();
        }
        else
        {
            waterCollider.SetActive(false);
            openSound.Stop();
            RunningWater.Stop();
        }
    }
}