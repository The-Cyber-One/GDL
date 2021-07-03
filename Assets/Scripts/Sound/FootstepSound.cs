using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{ 
    [SerializeField]
    GameObject player;

    private Vector3 curPos,lastPos;
    private AudioSource ad;
    void Start()
    {
        ad = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        curPos = player.transform.position;
        if (curPos != lastPos)
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
