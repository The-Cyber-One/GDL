using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Animator mouseAnimator;
    public GameObject mouse;
    public float minCheeseSize = 5;
    public SpellResize spellResize;

    private void OnTriggerStay(Collider other)
    {
       if (other.tag == "Cheese")
        {
            if (other.GetComponent<CollisionChecker>().collision)
            {
                if (other.transform.localScale.x >= minCheeseSize && !spellResize.movingCheese && other.GetComponent<CollisionChecker>().otherCollision.gameObject.CompareTag("Floor"))
                {
                    mouseAnimator.SetTrigger("EatCheese");
                    other.transform.parent = mouse.transform;
                }
            }
        }
    }
}
