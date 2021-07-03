using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotateFacingPlayer : MonoBehaviour
{
    public Transform player;
    [Range(-1f, 1f)]
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = player.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + player.transform.forward + new Vector3(0, height, 0);
        transform.LookAt(player);
    }
}
