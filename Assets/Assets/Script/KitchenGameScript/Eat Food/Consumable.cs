using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] GameObject[] portions;
    [SerializeField] int index = 0;

    public bool IsFinished => index == portions.Length;

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
            index++;
            Setvisual();
            _audioSource.Play();
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
