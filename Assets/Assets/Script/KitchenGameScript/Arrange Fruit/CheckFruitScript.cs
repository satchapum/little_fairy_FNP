using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class FruitTargetScript
{
    public string fruitName;
    public Sprite fruitImage;
    public int amountOfFruit;
}

public class CheckFruitScript : ArrangeScript
{
    [SerializeField] TMP_Text currentTargetText;
    [SerializeField] GameObject poseToGoNextObject;
    [SerializeField] List<FruitTargetScript> fruitTargetAndAmountOfFruit = new List<FruitTargetScript>();

    [SerializeField] GameObject textChildren;
    [SerializeField] GameObject copyOfTextPanel;

    public bool isFinish = false;
    string textResult = "";
    public int differenceOfNumber;

    public override void Start()
    {
        TutorialSoundManager.Instance.CheckCurrentScene();
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
            for (var i = textChildren.transform.childCount - 1; i >= 0; i--)
            {
                GameObject a = textChildren.transform.GetChild(i).gameObject;
                Destroy(a);
            }
            currentTargetText.text = "ผ่านแล้ว";
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
        for (var i = textChildren.transform.childCount - 1; i >= 0; i--)
        {
            GameObject a = textChildren.transform.GetChild(i).gameObject;
            Destroy(a);
        }
        for (int numberOfFruitTarget = 0; numberOfFruitTarget < fruitTargetAndAmountOfFruit.Count; numberOfFruitTarget++)
        {
            GameObject newText = Instantiate(copyOfTextPanel ,textChildren.transform, true);
            newText.transform.SetParent(textChildren.transform);
            newText.SetActive(true);
            newText.GetComponentInChildren<TMP_Text>().text = fruitTargetAndAmountOfFruit[numberOfFruitTarget].fruitName + " X" + fruitTargetAndAmountOfFruit[numberOfFruitTarget].amountOfFruit;
            newText.GetComponent<Image>().sprite = fruitTargetAndAmountOfFruit[numberOfFruitTarget].fruitImage;

            //textResult += fruitTargetAndAmountOfFruit[numberOfFruitTarget].fruitName + " : " + fruitTargetAndAmountOfFruit[numberOfFruitTarget].amountOfFruit + "\n";
        }
        currentTargetText.text = "";
    }
}
