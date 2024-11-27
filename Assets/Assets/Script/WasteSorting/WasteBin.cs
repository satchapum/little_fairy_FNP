using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

enum TypeOfBin
{
    Hazardous,
    Recycle,
    Wet,
    General
}

public class WasteBin : MonoBehaviour
{
    [SerializeField] TypeOfBin binType = new TypeOfBin();

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            WasteData wasteType = other.GetComponent<WasteData>();

            if (wasteType.wasteType.ToString() == binType.ToString())
            {
                Destroy(other.gameObject);

                if (binType.ToString() == "Hazardous")
                {
                    WasteManager.Instance.numberOfHazardousWaste--;
                }
                else if (binType.ToString() == "Recycle")
                {
                    WasteManager.Instance.numberOfRecycleWaste--;
                }
                else if (binType.ToString() == "Wet")
                {
                    WasteManager.Instance.numberOfWetWaste--;
                }
                else if (binType.ToString() == "General")
                {
                    WasteManager.Instance.numberOfGeneralWaste--;
                }

                WasteManager.Instance.source.clip = WasteManager.Instance.clip_Pass;
                WasteManager.Instance.source.Play();
            }

            else 
            {
                other.gameObject.transform.position = new Vector3(Random.Range(-14, -2), 0, Random.Range(-7, -9));
                WasteManager.Instance.source.clip = WasteManager.Instance.clip_Fail;
                WasteManager.Instance.source.Play();
            }
        }
        catch 
        {
            return;
        }
        
    }
}
