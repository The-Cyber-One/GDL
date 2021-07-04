using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessSpell : Spell
{
    [SerializeField]
    public Animator lightsOffAnim;
    public GameObject finalScrollPart2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lightsOffAnim.SetTrigger("PlayAnim");
            CurrentPlayer.parent.GetComponent<Concentrating>().Concentrate = true;
            finalScrollPart2.SetActive(true);
        }
    }
}
