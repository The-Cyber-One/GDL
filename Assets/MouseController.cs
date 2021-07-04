using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Animator mouseAnimator;
    public GameObject mouse;
    public float minCheeseSize = 5;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Cheese")
        {
            if (other.transform.localScale.x >= minCheeseSize)
            {
                mouseAnimator.SetTrigger("EatCheese");
                other.transform.parent = mouse.transform;
            }
        }
    }
}
