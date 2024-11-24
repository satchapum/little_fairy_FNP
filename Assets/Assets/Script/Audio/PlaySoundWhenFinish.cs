using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundWhenFinish : MonoBehaviour
{
    private void Start()
    {
        TutorialSoundManager.Instance.CheckCurrentScene();
    }
}
