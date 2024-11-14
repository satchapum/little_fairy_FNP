using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpongeRayCast : Singleton<SpongeRayCast>
{

    public bool isSpongeWet = false;
    public bool isSpongeHaveSoap = false;

    public RaycastHit hitOut;
    public bool isHit = false;
    public GameObject hitObject;

    [SerializeField] LayerMask layerMask;
    [SerializeField] float distanceToWash = 0.05f;

    [SerializeField] GameObject wetSpongeModel;
    [SerializeField] GameObject notWetSpongeModel;
    [SerializeField] GameObject wetAndSoapSpongeModel;
    [SerializeField] GameObject soapSpongeModel;

    void FixedUpdate()
    {
        if (!isSpongeWet || !isSpongeHaveSoap)
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
    public void ChangeSpongeModel(string inputObject)
    {
        if (isSpongeWet || isSpongeHaveSoap)
        {
            ChangeSpongeModelToSoapAndWet();
        }
        else if (inputObject == "Water")
        {
            ChangeSpongeModelToWet();
        }
        else if (inputObject == "Soap")
        {
            ChangeSpongeModelToSoap();
        }
    }

    private void ChangeSpongeModelToWet()
    {
        wetSpongeModel.SetActive(true);
        notWetSpongeModel.SetActive(false);
        soapSpongeModel.SetActive(true);
        wetAndSoapSpongeModel.SetActive(false);
    }

    private void ChangeSpongeModelToSoap()
    {
        wetSpongeModel.SetActive(false);
        soapSpongeModel.SetActive(true);
        notWetSpongeModel.SetActive(false);
        wetAndSoapSpongeModel.SetActive(false);
    }

    private void ChangeSpongeModelToSoapAndWet()
    {
        wetSpongeModel.SetActive(true);
        notWetSpongeModel.SetActive(false);
        wetAndSoapSpongeModel.SetActive(false);
    }
}