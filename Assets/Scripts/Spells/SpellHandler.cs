using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    public Spell activeSpell;
    public List<Spell> spells;
    public ParticleSystem shootPS;
    public Transform playerEyes;
    string playerTag = "Player";

    Camera FPS;

    // Start is called before the first frame update
    void Start()
    {
        FPS = playerEyes.GetComponent<Camera>();

        foreach (Spell spell in spells)
        {
            spell.gameObject.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerEyes.transform.position, FPS.transform.forward, out hit))
        {
            if (hit.transform.tag == playerTag && activeSpell == null)
            {
                activeSpell = spells[0];
                (spells[0] as SpellResize).Setup(playerEyes, hit.transform);
                MakeActive();
            }
        }
        else
        {
            activeSpell = null;
            MakeActive();
        }
    }

    void MakeActive()
    {
        foreach (Spell spell in spells)
        {
            if (activeSpell == spell)
            {
                spell.gameObject.SetActive(true);
            }
            else
            {
                spell.gameObject.SetActive(false);
            }
        }
    }
}