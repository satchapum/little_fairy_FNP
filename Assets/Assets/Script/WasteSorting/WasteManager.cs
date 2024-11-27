using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

public class WasteManager : Singleton<WasteManager>
{
    [SerializeField] bool IsGameFinish = false;
    [SerializeField] GameObject poseToGoNext;

    [Header("Canvas Setting")]
    [SerializeField] public TMP_Text statusText; 

    [Header("Number Of Waste")]
    [SerializeField] public int numberOfHazardousWaste;
    [SerializeField] public int numberOfRecycleWaste;
    [SerializeField] public int numberOfWetWaste;
    [SerializeField] public int numberOfGeneralWaste;
    
    public void UpdateTextStatus()
    {
        statusText.text = "จำนวนขยะที่ยังเหลืออยู่ " + numberOfHazardousWaste + numberOfRecycleWaste + numberOfWetWaste + numberOfGeneralWaste;
    }

    private void Update()
    {
        if (numberOfHazardousWaste + numberOfRecycleWaste + numberOfWetWaste + numberOfGeneralWaste == 0) 
        {
            poseToGoNext.SetActive(true);
            IsGameFinish = true;
        }
    }
}
