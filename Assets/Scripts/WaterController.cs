using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public CollisionChecker bucket;
    public float playerSizeMin, playerSizeMax;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool growing = false;
        if (bucket.trigger)
        {
            growing =
                bucket.trigger &&
                bucket.otherTrigger.CompareTag("Player") &&
                bucket.otherTrigger.transform.localScale.x >= playerSizeMin &&
                bucket.otherTrigger.transform.localScale.x <= playerSizeMax;

            Debug.Log(bucket.otherTrigger.transform.localScale);

            animator.SetBool("Growing", growing);
        }
    }

    public void StopAnimator()
    {
        animator.enabled = false;
    }
}
