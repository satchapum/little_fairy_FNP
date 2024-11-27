using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfWaste
{
    Hazardous,
    Recycle,
    Wet,
    General
}
public class WasteData : MonoBehaviour
{
    [SerializeField] public TypeOfWaste wasteType = new TypeOfWaste();

    private void Start()
    {
        if (wasteType.ToString() == "Hazardous")
        {
            WasteManager.Instance.numberOfHazardousWaste++;
        }
        else if (wasteType.ToString() == "Recycle")
        {
            WasteManager.Instance.numberOfRecycleWaste++;
        }
        else if (wasteType.ToString() == "Wet")
        {
            WasteManager.Instance.numberOfWetWaste++;
        }
        else if (wasteType.ToString() == "General")
        {
            WasteManager.Instance.numberOfGeneralWaste++;
        }
    }
}
