using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessSpell : Spell
{
    [SerializeField]
    private Animator lightsOffAnim;

    public Transform lightSwitch;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(CurrentPlayer.transform.position, CurrentPlayer.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform == lightSwitch)
                {
                    lightsOffAnim.SetTrigger("PlayAnim");
                    //reset?
                }
            }
        }
    }
}
