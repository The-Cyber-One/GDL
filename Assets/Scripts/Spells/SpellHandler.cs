using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    public Spell activeSpell;
    public List<Spell> spells;
    public ParticleSystem shootPS;
    public Transform playerEyes;
    public string playerTag = "Player";
    public LayerMask ObjectLayerMask;

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
        Vector3 rayOrigin = FPS.ViewportToScreenPoint(new Vector3(.5f, .5f, .0f));

        RaycastHit hit;
        if (Physics.Raycast(playerEyes.transform.position, FPS.transform.forward, out hit, Mathf.Infinity, ObjectLayerMask))
        {
            Debug.DrawLine(playerEyes.transform.position, hit.point, Color.blue);

            if (hit.transform.tag == playerTag)
            {
                activeSpell = spells[0];
                (spells[0] as SpellResize).EnableMe(hit);
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