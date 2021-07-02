using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : Spell
{
    [SerializeField]
    private Animator lightsOffAnim;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
            lightsOffAnim.SetTrigger("PlayAnim");
        }
    }
}
