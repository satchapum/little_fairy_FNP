using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonChange : Singleton<SpoonChange>
{
    [SerializeField] GameObject[] portions;
    [SerializeField] public int numberModelOfSpoon = 0;

    public bool IsFinished;

    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        Setvisual();
    }

    [ContextMenu("Consume")]
    public void Consume()
    {
        if (!IsFinished)
        {
            numberModelOfSpoon++;
            Setvisual();
            //_audioSource.Play();
            if (numberModelOfSpoon == portions.Length-1)
            {
                IsFinished = true;
            }
        }
        else if(IsFinished)
        {
            numberModelOfSpoon--;
            Setvisual();
            //_audioSource.Play();

            int firstNumberOfModel = 0;
            if (numberModelOfSpoon == firstNumberOfModel)
            {
                IsFinished = false;
            }
        }
    }

    void Setvisual()
    {
        for (int numberOfPortion = 0; numberOfPortion < portions.Length; numberOfPortion++)
        {
            portions[numberOfPortion].SetActive(numberOfPortion == numberModelOfSpoon);
        }
    }
}
