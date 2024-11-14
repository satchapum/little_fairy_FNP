using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpongeRayCast : Singleton<SpongeRayCast>
{

    public bool isSpongeWet = false;

    public RaycastHit hitOut;
    public bool isHit = false;
    public GameObject hitObject;

    [SerializeField] LayerMask layerMask;
    [SerializeField] float distanceToWash = 0.05f;

    [SerializeField] GameObject wetSpongeModel;
    [SerializeField] GameObject notWetSpongeModel;

    void FixedUpdate()
    {
        if (!isSpongeWet)
        {
            return;
        }

        if (transform.hasChanged)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, distanceToWash, layerMask))
            {
                hitOut = hit;
                isHit = true;
                hitObject = hit.collider.gameObject;
            }
            else
            {
                isHit = false;
            }

        }
        transform.hasChanged = false;
    }

    public void ChangeSpongeModel()
    {
        wetSpongeModel.SetActive(true);
        notWetSpongeModel.SetActive(false);
    }
}