using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public bool trigger = false, collision = false;
    public Collider otherTrigger;
    public Collision otherCollision;

    private void OnTriggerEnter(Collider other)
    {
        trigger = true;
        otherTrigger = other;
    }

    private void OnTriggerExit(Collider other)
    {
        trigger = false;
        otherTrigger = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.collision = true;
        otherCollision = collision;
    }

    private void OnCollisionExit(Collision collision)
    {
        this.collision = false;
        otherCollision = null;
    }
}
