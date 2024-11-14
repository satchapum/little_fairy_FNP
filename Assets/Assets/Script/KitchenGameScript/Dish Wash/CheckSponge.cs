using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSponge : MonoBehaviour
{
    [SerializeField] GameObject spongeCollider;
    [SerializeField] string typeOfLiquid;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == spongeCollider)
        {
            SpongeRayCast.Instance.ChangeSpongeModel(typeOfLiquid);
        }
    }
}