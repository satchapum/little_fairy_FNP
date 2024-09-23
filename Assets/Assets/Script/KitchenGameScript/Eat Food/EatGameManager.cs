using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EatGameManager : Singleton<EatGameManager>
{
    [SerializeField] public bool isEatStateFinish;
    [SerializeField] TMP_Text canvasShowFinish;

    [Header("GameObject to set active")]
    [SerializeField] GameObject grabblePlate;
    [SerializeField] GameObject inGrabblePlate;

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
            canvasShowFinish.text = "Finish";
            grabblePlate.SetActive(true);
            inGrabblePlate.SetActive(false);
        }
    }
}
