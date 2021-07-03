using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    private GameObject[] players;
    private int enabledPlayer = 0;
    Camera activeCamera;

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
        Camera cam = players[index].GetComponentInChildren<Camera>();
        cam.enabled = boolean;

        Transform wizard = players[index].transform.Find("Wizard");
        foreach (Transform transform in wizard)
        {
            if (boolean)
            {
                transform.gameObject.layer = LayerMask.NameToLayer("TransparentFX");
            }
            else
            {
                transform.gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
        foreach (Transform transform in wizard.Find("Staff"))
        {
            transform.gameObject.layer = LayerMask.NameToLayer("Player");
        }

        players[index].GetComponentInChildren<CameraController>().enabled = boolean;
        players[index].GetComponent<PlayerMovement>().canMove = boolean;
        players[index].GetComponentInChildren<AudioListener>().enabled = boolean;
        if (boolean)
        {
            ActiveCamera = cam;
        }
    }

    public Camera ActiveCamera
    {
        get { return activeCamera; }
        set { activeCamera = value; }
    }
}
