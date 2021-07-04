using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessSpell : Spell
{
    [SerializeField]
    public Animator lightsOffAnim;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CurrentPlayer.parent.GetComponent<Concentrating>().Concentrate = true;
        }
    }
}
