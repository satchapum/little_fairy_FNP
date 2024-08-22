using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class FruitTargetScript
{
    public string fruitName;
    public int amountOfFruit;
}

public class CheckFruitScript : ArrangeScript
{
    [SerializeField] TMP_Text currentTargetText;

    [SerializeField] List<FruitTargetScript> fruitTargetAndAmountOfFruit = new List<FruitTargetScript>();

    private int currentAmoutOfFruitTarget = 0;

    public bool isNoFruit = false;


    public override void Start()
    {
        UpdateCurrentAmoutOfTarget();
    }

    public override void UpdateCurrentAmoutOfTarget()
    {
        currentAmoutOfFruitTarget = 0;
        for (int typeOfFruit = 0; typeOfFruit < fruitTargetAndAmountOfFruit.Count; typeOfFruit++)
        {
            currentAmoutOfFruitTarget += fruitTargetAndAmountOfFruit[typeOfFruit].amountOfFruit;
        }

        CheckIsFinish();
    }

    public override void CheckIsFinish()
    {
        if (currentAmoutOfFruitTarget == 0)
        {
            currentTargetText.text = "FINISH";
            isNoFruit = true;
        }
        else
        {
            currentTargetText.text = "The Fruit left\n" + currentAmoutOfFruitTarget;
            isNoFruit = false;
        }
    }

    public override void OnTriggerEnter(Collider fruitCollider)
    {
        actionWhenCollider(true, fruitCollider);
    }

    public override void OnTriggerExit(Collider fruitCollider)
    {
        actionWhenCollider(false, fruitCollider);
    }

    public override void actionWhenCollider(bool IsEnter, Collider fruitCollider)
    {
        for (int numberOfFruitTarget = 0; numberOfFruitTarget < fruitTargetAndAmountOfFruit.Count; numberOfFruitTarget++)
        {
            if (fruitCollider.gameObject.GetComponent<FruitScript>() != null)
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

                    UpdateCurrentAmoutOfTarget();
                    break;
                }
            }
        }
    }
}
