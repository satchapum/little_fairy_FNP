using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Consumable : MonoBehaviour
{
    [SerializeField] TMP_Text canvasShowFinish;

    [SerializeField] GameObject[] portions;
    [SerializeField] int index = 0;

    [SerializeField] public bool isFinished => index == portions.Length-1;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        Setvisual();
        canvasShowFinish.text = "Not Finish";
    }

    private void Update()
    {
        if (isFinished && SpoonChange.Instance.numberModelOfSpoon == 0)
        {
            EatGameManager.Instance.isEatStateFinish = true;

        }
    }

    [ContextMenu("Consume")]
    public void Consume()
    {
        if (!isFinished)
        {
            index++;
            Setvisual();
            _audioSource.Play();
            canvasShowFinish.text = "Not Finish";
        }
    }

    void Setvisual()
    {
        for (int numberOfPortion = 0; numberOfPortion < portions.Length; numberOfPortion++)
        {
            portions[numberOfPortion].SetActive(numberOfPortion == index);
        }
    }
}
