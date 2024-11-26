using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EatGameManager : Singleton<EatGameManager>
{
    [SerializeField] public bool isThisMiniGameFinish;
    [SerializeField] public bool isEatStateFinish;
    [SerializeField] GameObject poseToGoNextObject;
    [SerializeField] TMP_Text canvasShowFinish;

    [Header("GameObject to set active")]
    [SerializeField] GameObject grabblePlate;
    [SerializeField] GameObject inGrabblePlate;
    [SerializeField] int numberOfSoundplayAndSetObject;
    void Start()
    {
        grabblePlate.SetActive(false);
        inGrabblePlate.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEatStateFinish)
        {
            if (numberOfSoundplayAndSetObject == 0)
            {
                numberOfSoundplayAndSetObject++;
                TutorialSoundManager.Instance.KitchenForDoJobTutorial();
                canvasShowFinish.text = "Move plate to the sink";
                grabblePlate.SetActive(true);
                inGrabblePlate.SetActive(false);
                poseToGoNextObject.SetActive(false);
            }
            
            
        }

        if (isThisMiniGameFinish)
        {
            poseToGoNextObject.SetActive(true);
            canvasShowFinish.text = "Finish";
        }
    }
}
