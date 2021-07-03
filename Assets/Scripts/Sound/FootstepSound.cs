using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{ 
    private Vector3 curPos,lastPos;
    private AudioSource ad;
    private PlayerMovement playerMovement;
    void Start()
    {
        ad = gameObject.GetComponent<AudioSource>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        curPos = transform.position;
        if (curPos != lastPos && playerMovement.isGrounded)
        {
            if (!ad.isPlaying)
            {
                ad.volume = Random.Range(0.6f, 0.8f);
                ad.pitch = Random.Range(1, 1.2f);
                ad.Play();
            }
        }
        else
        {
            ad.Stop();
        }

        lastPos = curPos;
    }
}
