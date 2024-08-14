using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatScript : MonoBehaviour
{
    Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        SpoonChange consumable = other.GetComponent<SpoonChange>();

        int spoonWithFood = 1;
        if (consumable != null && consumable.numberModelOfSpoon == spoonWithFood)
        {
            consumable.Consume();
        }
    }
}
