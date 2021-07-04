using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessSpell : Spell
{
    [SerializeField]
    private Animator lightsOffAnim;
    public GameObject finalScrollPart2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lightsOffAnim.SetTrigger("PlayAnim");
            finalScrollPart2.SetActive(true);
            CurrentPlayer.parent.GetComponent<Concentrating>().Concentrate = true;
        }
    }
}
