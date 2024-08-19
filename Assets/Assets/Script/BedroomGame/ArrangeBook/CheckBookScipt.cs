using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTargetScript
{
    public string bookName;
    public int amountOfBook;
}

public class CheckBookScipt : ArrangeScript
{
    [SerializeField] List<BookTargetScript> bookTargetAndAmountOfBook = new List<BookTargetScript>();

    private int currentAmoutOfBookTarget = 0;

    public bool IsNoBook = false;


    public override void Start()
    {
        UpdateCurrentAmoutOfTarget();
    }

    public override void UpdateCurrentAmoutOfTarget()
    {
        currentAmoutOfBookTarget = 0;
        for (int typeOfFruit = 0; typeOfFruit < bookTargetAndAmountOfBook.Count; typeOfFruit++)
        {
            currentAmoutOfBookTarget += bookTargetAndAmountOfBook[typeOfFruit].amountOfBook;
        }

        CheckIsNoTarget();
    }

    public override void CheckIsNoTarget()
    {
        if (currentAmoutOfBookTarget == 0)
        {
            IsNoBook = true;
        }
        else
        {
            IsNoBook = false;
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
        for (int numberOfBookTarget = 0; numberOfBookTarget < bookTargetAndAmountOfBook.Count; numberOfBookTarget++)
        {
            if (fruitCollider.gameObject.GetComponent<FruitScript>().fruitName == bookTargetAndAmountOfBook[numberOfBookTarget].bookName)
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
