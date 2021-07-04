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
            lightsOffAnim.SetTrigger("PlayAnim");
        }
    }
}
