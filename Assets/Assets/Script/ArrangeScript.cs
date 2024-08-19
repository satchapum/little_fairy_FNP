using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArrangeScript : MonoBehaviour
{
    public abstract void Start();

    public abstract void UpdateCurrentAmoutOfTarget();

    public abstract void CheckIsNoTarget();

    public abstract void OnTriggerEnter(Collider fruitCollider);

    public abstract void OnTriggerExit(Collider fruitCollider);

    public abstract void actionWhenCollider(bool IsEnter, Collider fruitCollider);
}
