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
    [SerializeField] GameObject poseToGoNextObject;
    [SerializeField] List<FruitTargetScript> fruitTargetAndAmountOfFruit = new List<FruitTargetScript>();

    public bool isFinish = false;
    string textResult = "";
    public int differenceOfNumber;

    public override void Start()
    {
        CheckIsFinish();
        ShowFruitData();
    }

    public override void CheckIsFinish()
    {
        isFinish = false;
        int numberOfFinish = 0;

        for (int typeOfFruit = 0; typeOfFruit < fruitTargetAndAmountOfFruit.Count; typeOfFruit++)
        {
            if (fruitTargetAndAmountOfFruit[typeOfFruit].amountOfFruit == 0)
            {
                numberOfFinish++;
            }
        }
        if (numberOfFinish == fruitTargetAndAmountOfFruit.Count)
        {
            poseToGoNextObject.SetActive(true);
            currentTargetText.text = "Finish";
            isFinish = true;
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
                    if (IsEnter)
                    {
                        fruitTargetAndAmountOfFruit[numberOfFruitTarget].amountOfFruit -= 1;
                    }
                    else
                    {
                        fruitTargetAndAmountOfFruit[numberOfFruitTarget].amountOfFruit += 1;
                    }
                    ShowFruitData();
                    CheckIsFinish();
                    break;
                }
                
            }
        }
    }
    private void ShowFruitData()
    {
        textResult = "";
        for (int numberOfFruitTarget = 0; numberOfFruitTarget < fruitTargetAndAmountOfFruit.Count; numberOfFruitTarget++)
        {
            textResult += fruitTargetAndAmountOfFruit[numberOfFruitTarget].fruitName + " : " + fruitTargetAndAmountOfFruit[numberOfFruitTarget].amountOfFruit + "\n";
        }
        currentTargetText.text = textResult;
    }
}
