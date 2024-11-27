using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteManager : Singleton<WasteManager>
{

    [Header("Number Of Waste")]
    [SerializeField] public int numberOfHazardousWaste;
    [SerializeField] public int numberOfRecycleWaste;
    [SerializeField] public int numberOfWetWaste;
    [SerializeField] public int numberOfGeneralWaste;

    private void Start()
    {
        
    }
    
}
