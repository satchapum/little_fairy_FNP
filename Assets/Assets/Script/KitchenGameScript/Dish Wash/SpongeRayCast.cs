using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpongeRayCast : MonoBehaviour
{
    public RaycastHit hitOut;
    public bool IsHit = false;
    public GameObject hitObject;

    [SerializeField] LayerMask layerMask;
    [SerializeField] float distanceToWash = 0.05f;

    void FixedUpdate()
    {
        if (transform.hasChanged)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, distanceToWash, layerMask))
            {
                hitOut = hit;
                IsHit = true;
                hitObject = hit.collider.gameObject;
            }
            else
            {
                IsHit = false;
            }
            
        }
        transform.hasChanged = false;
    }
}
