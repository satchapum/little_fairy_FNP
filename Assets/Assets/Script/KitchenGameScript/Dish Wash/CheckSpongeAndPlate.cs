using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpongeAndPlate : MonoBehaviour
{
    [SerializeField] GameObject spongeCollider;
    [SerializeField] List<GameObject> plateList = new List<GameObject>();
    [SerializeField] string typeOfLiquid;
   
    private void Awake()
    {
        DishWashScript[] dishes = FindObjectsOfType<DishWashScript>();
        
        foreach (DishWashScript dish in dishes)
        {
            GameObject parentGameObject = dish.transform.parent.gameObject;
            plateList.Add(parentGameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == spongeCollider)
        {
            SpongeRayCast.Instance.ChangeSpongeModel(typeOfLiquid);
        }

        else
        {
            foreach (GameObject plate in plateList)
            {
                if (other.gameObject == plate)
                {
                    DishWashScript dishWashScript = plate.GetComponentInChildren<DishWashScript>();
                    Debug.Log("Before change to true");
                    if (dishWashScript.isClean == true)
                    {
                        Debug.Log("Change to true");
                        dishWashScript.SetStatusToClean();
                    }
                }
            }
        }
       
    }
}