using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    private GameObject[] players;
    private int enabledPlayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        players = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            players[i] = transform.GetChild(i).gameObject;

            SwitchState(i, false);
        }

        SwitchState(enabledPlayer, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchPlayer();
        }
    }

    void SwitchPlayer()
    {
        SwitchState(enabledPlayer, false);

        enabledPlayer++;
        if (enabledPlayer >= players.Length) enabledPlayer = 0;

        SwitchState(enabledPlayer, true);
    }

    void SwitchState(int index, bool boolean)
    {
        players[index].GetComponentInChildren<Camera>().enabled = boolean;
        players[index].GetComponentInChildren<CameraController>().enabled = boolean;
        players[index].GetComponent<PlayerMovement>().canMove = boolean;
        players[index].GetComponentInChildren<AudioListener>().enabled = boolean;
    }

    public Camera ActivePlayerCamera()
    {
        foreach (GameObject player in players)
        {
            Camera cam = player.GetComponentInChildren<Camera>(); //yikes!!!!!
            if (cam.enabled)
            {
                return cam;
            }
        }
        return null;
    }
}
