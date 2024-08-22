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

    private int currentAmoutOfBookTarget = 0;

    public bool isNoBook = false;


    public override void Start()
    {

        UpdateCurrentAmoutOfTarget();
    }

    public override void UpdateCurrentAmoutOfTarget()
    {
        currentAmoutOfBookTarget = 0;
        for (int typeOfBook = 0; typeOfBook < bookTargetAndAmountOfBook.Count; typeOfBook++)
        {
            currentAmoutOfBookTarget += bookTargetAndAmountOfBook[typeOfBook].amountOfBook;
        }

        CheckIsFinish();
    }

    public override void CheckIsFinish()
    {

        if (currentAmoutOfBookTarget == 0)
        {
            currentTargetText.text = "FINISH";
            poseToGoNextObject.SetActive(true);
            isNoBook = true;
        }
        else
        {
            currentTargetText.text = "The book left\n" + currentAmoutOfBookTarget;
            isNoBook = false;
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

                    UpdateCurrentAmoutOfTarget();
                    break;
                }
            }
        }
    }
}
