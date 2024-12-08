using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpongeRayCast : Singleton<SpongeRayCast>
{

    public bool isSpongeWet = false;
    public bool isSpongeHaveSoap = false;
    public int numberToPlaySound = 0;
    [SerializeField] AudioSource spongeAudioSource;

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
                if (numberToPlaySound == 0)
                {
                    numberToPlaySound++;
                    spongeAudioSource.Play();
                }
                hitOut = hit;
                isHit = true;
                hitObject = hit.collider.gameObject;
            }
            else
            {
                numberToPlaySound = 0;
                isHit = false;
            }

        }
        transform.hasChanged = false;
    }
    public void ChangeSpongeModel(string inputObject)
    {
        if (inputObject == "Water" && !isSpongeHaveSoap)
        {
            ChangeSpongeModelToWet();
        }
        else if (inputObject == "Soap" && !isSpongeWet)
        {
            ChangeSpongeModelToSoap();
        }
        else if (isSpongeWet || isSpongeHaveSoap)
        {
            
            ChangeSpongeModelToSoapAndWet();

            //Add Audio Here
            TutorialSoundManager.Instance.KitchenForDoJobTutorial();
        }
    }

    private void ChangeSpongeModelToWet()
    {
        isSpongeWet = true;

        wetSpongeModel.SetActive(true);
        notWetSpongeModel.SetActive(false);
        soapSpongeModel.SetActive(false);
        wetAndSoapSpongeModel.SetActive(false);
    }

    private void ChangeSpongeModelToSoap()
    {
        isSpongeHaveSoap = true;

        wetSpongeModel.SetActive(false);
        soapSpongeModel.SetActive(true);
        notWetSpongeModel.SetActive(false);
        wetAndSoapSpongeModel.SetActive(false);
    }

    private void ChangeSpongeModelToSoapAndWet()
    {
        isSpongeWet = true;
        isSpongeHaveSoap = true;

        wetSpongeModel.SetActive(false);
        notWetSpongeModel.SetActive(false);
        soapSpongeModel.SetActive(false);
        wetAndSoapSpongeModel.SetActive(true);
    }
}