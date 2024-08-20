using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopScript : MonoBehaviour
{
    [SerializeField] SpoonChange mainSpoon;
    [SerializeField] GameObject foodTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != foodTarget) return;

        Consumable consumable = other.GetComponent<Consumable>();
        SpoonChange spoonChange = mainSpoon.GetComponent<SpoonChange>();

        int spoonWithOutFood = 0;
        if (consumable != null && !consumable.IsFinished && spoonChange.numberModelOfSpoon == spoonWithOutFood)
        {
            consumable.Consume();

            spoonChange.Consume();
        }
    }
}
