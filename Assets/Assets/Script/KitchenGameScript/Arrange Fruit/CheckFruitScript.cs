using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FruitTargetScript
{
    public string fruitName;
    public int amountOfFruit;
}

public class CheckFruitScript : MonoBehaviour
{
    [SerializeField] ListOfFruitScript listOfFruit;
    [SerializeField] List<FruitTargetScript> fruitTargetAndAmountOfFruit = new List<FruitTargetScript>();

    private int currentAmoutOfFruitTarget = 0;
    private List<GameObject> listOfFruitGameobject;

    public bool IsNoFruit = false;

    void Start()
    {
        UpdateCurrentAmoutOfFruitTarget();

        listOfFruitGameobject = listOfFruit.listOfFruitGameobject;
    }

    private void UpdateCurrentAmoutOfFruitTarget()
    {
        currentAmoutOfFruitTarget = 0;
        for (int typeOfFruit = 0; typeOfFruit < fruitTargetAndAmountOfFruit.Count; typeOfFruit++)
        {
            currentAmoutOfFruitTarget += fruitTargetAndAmountOfFruit[typeOfFruit].amountOfFruit;
        }

        CheckIsNoFruit();
    }

    private void CheckIsNoFruit()
    {
        if (currentAmoutOfFruitTarget == 0)
        {
            IsNoFruit = true;
        }
        else
        {
            IsNoFruit = false;
        }
    }

    private void OnTriggerEnter(Collider fruitCollider)
    {
        actionWhenCollider(true, fruitCollider);
    }

    private void OnTriggerExit(Collider fruitCollider)
    {
        actionWhenCollider(false, fruitCollider);
    }

    private void actionWhenCollider(bool IsEnter, Collider fruitCollider)
    {
        for (int numberOfFruitTarget = 0; numberOfFruitTarget < fruitTargetAndAmountOfFruit.Count; numberOfFruitTarget++)
        {
            if (fruitCollider.gameObject.GetComponent<FruitScript>().fruitName == fruitTargetAndAmountOfFruit[numberOfFruitTarget].fruitName)
            {
                if (IsEnter == true)
                {
                    fruitTargetAndAmountOfFruit[numberOfFruitTarget].amountOfFruit -= 1;
                }
                else
                {
                    fruitTargetAndAmountOfFruit[numberOfFruitTarget].amountOfFruit += 1;
                }
                    
                UpdateCurrentAmoutOfFruitTarget();
                break;
            }
        }
    }
}
