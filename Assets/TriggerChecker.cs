using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    public bool colliding = false;
    public Collider other;

    private void OnTriggerEnter(Collider other)
    {
        colliding = true;
        this.other = other;
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
        this.other = null;
    }
}
