using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookStatus : MonoBehaviour
{
    [SerializeField] bool isBookOnGrab;

    public void SetBookOnGrab()
    {
        isBookOnGrab = true;
    }

    public void SetBookIsNotOnGrab()
    {
        isBookOnGrab = false;
    } 
}
