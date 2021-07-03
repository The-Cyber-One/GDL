using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public TriggerChecker bucket;
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

        bool growing =
            bucket.colliding && 
            bucket.other.CompareTag("Player") && 
            bucket.other.transform.localScale.x >= playerSizeMin && 
            bucket.other.transform.localScale.x <= playerSizeMax;

        Debug.Log(bucket.other.transform.localScale);

        animator.SetBool("Growing", growing);
    }
}
