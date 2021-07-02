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
                ad.volume = Random.Range(0.8f, 1);
                ad.pitch = Random.Range(0.8f, 1.1f);
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
