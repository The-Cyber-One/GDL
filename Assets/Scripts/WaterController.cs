using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public CollisionChecker bucket;
    public float playerSizeMin, playerSizeMax;

    private Animator animator;
    public AudioSource soundEffectWater;

    bool hasPlayed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool growing = false;
        if (bucket.trigger && !hasPlayed)
        {
            growing =
                bucket.otherTrigger.CompareTag("Player") &&
                bucket.otherTrigger.transform.localScale.x >= playerSizeMin &&
                bucket.otherTrigger.transform.localScale.x <= playerSizeMax;

            if (growing)
            {
                hasPlayed = true;
                animator.SetBool("Growing", true);
                soundEffectWater.Play();
            }
        }
    }

    public void StopAnimator()
    {
        animator.enabled = false;
    }
}
