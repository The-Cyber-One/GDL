using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSpell : Spell
{
    bool openTheDoor;
    public GameObject doorRight;
    public GameObject doorLeft;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(CurrentPlayer.transform.position, CurrentPlayer.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject == doorRight || hit.transform.gameObject == doorLeft)
                {
                    openTheDoor = true;
                }
            }
        }
        if (openTheDoor)
        {
            doorLeft.transform.rotation = Quaternion.Lerp(doorLeft.transform.rotation, Quaternion.Euler(-90, 0, -120), 0.001f);
            doorRight.transform.rotation = Quaternion.Lerp(doorRight.transform.rotation, Quaternion.Euler(-90, -0, 120), 0.001f);
        }
    }
}
