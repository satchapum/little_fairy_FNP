using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSnap : MonoBehaviour
{
    public bool isHaveABook;
    private void OnTriggerEnter(Collider bookObj)
    {
        if (isHaveABook) return;

        if (bookObj.GetComponent<BookStatus>() != null && !bookObj.GetComponent<BookStatus>().isBookOnGrab)
        {
            isHaveABook = true;
            GameObject bookPivotObj = bookObj.gameObject;

            bookPivotObj.transform.position = gameObject.transform.position;
            bookPivotObj.transform.rotation = gameObject.transform.rotation;

            Debug.Log(bookObj);
            Debug.Log(bookPivotObj);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isHaveABook = false;
    }
}
