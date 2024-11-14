using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpongeWet : MonoBehaviour
{
    [SerializeField] GameObject spongeCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == spongeCollider)
        {
            SpongeRayCast.Instance.isSpongeWet = true;
            SpongeRayCast.Instance.ChangeSpongeModel();
        }
    }
}