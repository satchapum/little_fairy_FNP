using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DishWashManager : MonoBehaviour
{
    [SerializeField] List<DishWashScript> dishList;
    [SerializeField] TMP_Text Showpercentage;
    [SerializeField] GameObject poseToGoNextObject;

    public bool isAllHandEmptyOrNotEmpty;
    public bool isGameFinish;

    private void Start()
    {
        isGameFinish = false;
        CheckDishGrab();
    }

    private void Update()
    {
        ShowDataOnText();
        CheckAllDishIsClean();
    }

    private void ShowDataOnText()
    {
        CheckDishGrab();
        if (isGameFinish)
        {
            Showpercentage.text = "Finish";
            return;
        }
        Showpercentage.text = "";
        if (isAllHandEmptyOrNotEmpty)
        {
            int firtNumberOfDish = 0;
            for (int numberOfDish = firtNumberOfDish; numberOfDish < dishList.Count; numberOfDish++)
            {
                if (dishList[numberOfDish].dirtAmountPercentage <= 15)
                {
                    Showpercentage.text += "Dish Number " + (numberOfDish + 1) + " : " + "Finish\n";
                }
                else
                {
                    Showpercentage.text += "Dish Number " + (numberOfDish + 1) + " : " + dishList[numberOfDish].dirtAmountPercentage + "\n";
                }
                
            }
        }
        else
        {
            int firtNumberOfDish = 0;
            for (int numberOfDish = firtNumberOfDish; numberOfDish < dishList.Count; numberOfDish++)
            {
                if (dishList[numberOfDish].isDishOnGrab)
                {
                    if (dishList[numberOfDish].dirtAmountPercentage <= 15)
                    { 
                        Showpercentage.text += "Dish Number " + (numberOfDish + 1) + " : " + "Finish";
                        break;
                    }
                    else
                    {
                        Showpercentage.text += "Dish Number " + (numberOfDish + 1) + " : " + dishList[numberOfDish].dirtAmountPercentage;

                    }
                }
            }
        }
    }

    private void CheckDishGrab()
    {
        isAllHandEmptyOrNotEmpty = false;
        int firtNumberOfDish = 0;
        int numberOfHandGrab = 0;
        for (int numberOfDish = firtNumberOfDish; numberOfDish < dishList.Count; numberOfDish++)
        {
            if (dishList[numberOfDish].isDishOnGrab)
            {
                numberOfHandGrab++;
            }
        }
        if (numberOfHandGrab == 2 || numberOfHandGrab == 0)
        {
            isAllHandEmptyOrNotEmpty = true;
        }
    }

    private void CheckAllDishIsClean()
    {
        int firtNumberOfDish = 0;
        int numberOfFinishDish = 0;
        for (int numberOfDish = firtNumberOfDish; numberOfDish < dishList.Count; numberOfDish++)
        {
            if (dishList[numberOfDish].isFinish)
            {
                numberOfFinishDish++;
            }
        }
        if (numberOfFinishDish == dishList.Count)
        {
            isGameFinish = true;
            poseToGoNextObject.SetActive(true);
        }
        
    }
}
