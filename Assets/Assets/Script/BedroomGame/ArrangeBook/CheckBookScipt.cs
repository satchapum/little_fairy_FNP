using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class BookTargetScript
{
    public string bookName;
    public int amountOfBook;
    
}

public class CheckBookScipt : ArrangeScript
{
    [SerializeField] TMP_Text currentTargetText;
    [SerializeField] List<BookTargetScript> bookTargetAndAmountOfBook = new List<BookTargetScript>();
    [SerializeField] GameObject poseToGoNextObject;

    public bool isFinish = false;
    public int maxAmountOfBook;


    public override void Start()
    {
        for (int numberOfBook = 0; numberOfBook < bookTargetAndAmountOfBook.Count; numberOfBook++)
        {
            maxAmountOfBook += bookTargetAndAmountOfBook[numberOfBook].amountOfBook;
        }
        CheckIsFinish();
    }

    public override void CheckIsFinish()
    {
        isFinish = false;
        int numberOfFinish = 0;

        for (int typeOfFruit = 0; typeOfFruit < bookTargetAndAmountOfBook.Count; typeOfFruit++)
        {
            currentTargetText.text = bookTargetAndAmountOfBook[typeOfFruit].amountOfBook + "/" + maxAmountOfBook;
            if (bookTargetAndAmountOfBook[typeOfFruit].amountOfBook == 0)
            {
                numberOfFinish++;
            }
        }
        if (numberOfFinish == bookTargetAndAmountOfBook.Count)
        {
            poseToGoNextObject.SetActive(true);
            currentTargetText.text = "Finish";
            isFinish = true;
        }
    }

    public override void OnTriggerEnter(Collider bookCollider)
    {
        actionWhenCollider(true, bookCollider);
    }

    public override void OnTriggerExit(Collider bookCollider)
    {
        actionWhenCollider(false, bookCollider);
    }

    public override void actionWhenCollider(bool IsEnter, Collider bookCollider)
    {
        for (int numberOfBookTarget = 0; numberOfBookTarget < bookTargetAndAmountOfBook.Count; numberOfBookTarget++)
        {
            if (bookCollider.gameObject.GetComponent<BookScript>() != null)
            {
                if (bookCollider.gameObject.GetComponent<BookScript>().bookName == bookTargetAndAmountOfBook[numberOfBookTarget].bookName)
                {
                    if (IsEnter == true)
                    {
                        bookTargetAndAmountOfBook[numberOfBookTarget].amountOfBook -= 1;
                    }
                    else
                    {
                        bookTargetAndAmountOfBook[numberOfBookTarget].amountOfBook += 1;
                    }
                    CheckIsFinish();
                    break;
                }
            }
        }
    }
}
